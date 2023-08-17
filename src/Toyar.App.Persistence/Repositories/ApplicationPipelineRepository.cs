using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Persistence.Repositories;

public class ApplicationPipelineRepository : EfCoreAggregateRootRepository<ApplicationPipeline, string>, IApplicationPipelineRepository
{
    private readonly IDictionary<string, ApplicationPipeline> _applicationPipelineForId;


    public ApplicationPipelineRepository(ILuckDbContext dbContext) : base(dbContext)
    {
        _applicationPipelineForId = new Dictionary<string, ApplicationPipeline>();
    }


    public async Task<ApplicationPipeline> FindFirstByIdAsync(string id)
    {
        if (_applicationPipelineForId.TryGetValue(id, out var async))
        {
            return async;
        }

        var applicationPipeline = await FindAll(x => x.Id == id)
            .Include(x=>x.PipelineHistories).FirstOrDefaultAsync();
        if (applicationPipeline is null)
        {
            throw new BusinessException($"流水线不存在");
        }

        _applicationPipelineForId.Add(id, applicationPipeline);
        return applicationPipeline;
    }


    public async Task<(ApplicationPipelinePipelineOutputDto[] Data, int TotalCount)> GetApplicationPipelinePageListAsync(string appId, PipelineQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
            .WhereIf(x => x.Published == query.Published, query.Published.HasValue);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var outputList = list.Select(x => new ApplicationPipelinePipelineOutputDto
        {
            Id = x.Id,
            Name = x.Name,
            Published = x.Published,
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
        var list = await FindAll(x => x.PipelineHistories.Any(record => record.PipelineBuildState == PipelineBuildStateEnum.Running))
            .Include(x => x.PipelineHistories.Where(x => x.PipelineBuildState == PipelineBuildStateEnum.Running)).ToArrayAsync();
        return list;
    }
}