using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Repositories;

public class ApplicationPipelineRepository : EfCoreAggregateRootRepository<ApplicationPipeline, string>, IApplicationPipelineRepository
{
    private readonly IDictionary<string, ApplicationPipeline> _applicationPipelineForId;


    public ApplicationPipelineRepository(ILuckDbContext dbContext) : base(dbContext)
    {
        _applicationPipelineForId = new Dictionary<string, ApplicationPipeline>();
    }


    public async Task<ApplicationPipeline> FindFirstByIdAsync(string id)
    {
        if (_applicationPipelineForId.ContainsKey(id))
        {
            return _applicationPipelineForId[id];
        }

        var applicationPipeline = await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if (applicationPipeline is null)
        {
            throw new BusinessException($"流水线不存在");
        }

        _applicationPipelineForId.Add(id, applicationPipeline);
        return applicationPipeline;
    }


    public async Task<(ApplicationPipelineOutputDto[] Data, int TotalCount)> GetApplicationPipelinePageListAsync(string appId, ApplicationPipelineQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .Include(x => x.ApplicationPipelineExecutedRecords)
            .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
            .WhereIf(x => x.Published == query.Published, query.Published.HasValue);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var outputList = list.Select(x => new ApplicationPipelineOutputDto
        {
            Id = x.Id,
            Name = x.Name,
            Published = x.Published,
            AppEnvironmentId = x.AppEnvironmentId,
            PipelineBuildState = x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber) != null ? x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber)!.PipelineBuildState : PipelineBuildStateEnum.Ready,
            JenkinsBuildNumber = x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber) != null ? x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber)!.JenkinsBuildNumber : 0,
            LastApplicationPipelineExecutedRecordId = x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber) != null ? x.ApplicationPipelineExecutedRecords.MaxBy(record => record.JenkinsBuildNumber)!.Id : "",
            PipelineScript = x.PipelineScript.Select(stage =>
            {
                var steps = stage.Steps.Select(step => new StepDto()
                {
                    Name = step.Name,
                    Content = step.Content,
                    StepType = step.StepType,
                }).ToList();
                return new StageDto
                {
                    Name = stage.Name,
                    Steps = steps,
                };
            }).ToList(),
        }).ToArray();
        var totalCount = await queryable.CountAsync();
        return (outputList, totalCount);
    }


    /// <summary>
    /// 查询运行记录有存在运行状态的所有流水线和运行状态的运行记录
    /// </summary>
    /// <returns></returns>
    public async Task<ApplicationPipeline[]> GetRunningApplicationPipelineAsync()
    {
        var list = await FindAll(x => x.ApplicationPipelineExecutedRecords.Any(record => record.PipelineBuildState == PipelineBuildStateEnum.Running))
            .Include(x => x.ApplicationPipelineExecutedRecords.Where(x => x.PipelineBuildState == PipelineBuildStateEnum.Running)).ToArrayAsync();
        return list;
    }
}