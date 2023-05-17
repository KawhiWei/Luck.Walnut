using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Persistence.Repositories;

public class PipelineRepository : EfCoreAggregateRootRepository<Pipeline, string>, IPipelineRepository
{
    private readonly IDictionary<string, Pipeline> _applicationPipelineForId;


    public PipelineRepository(ILuckDbContext dbContext) : base(dbContext)
    {
        _applicationPipelineForId = new Dictionary<string, Pipeline>();
    }


    public async Task<Pipeline> FindFirstByIdAsync(string id)
    {
        if (_applicationPipelineForId.ContainsKey(id))
        {
            return _applicationPipelineForId[id];
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


    public async Task<(PipelineOutputDto[] Data, int TotalCount)> GetApplicationPipelinePageListAsync(string appId, PipelineQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
            .WhereIf(x => x.Published == query.Published, query.Published.HasValue);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var outputList = list.Select(x => new PipelineOutputDto
        {
            Id = x.Id,
            Name = x.Name,
            Published = x.Published,
            AppEnvironmentId = x.Environment,
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
    public async Task<Pipeline[]> GetRunningApplicationPipelineAsync()
    {
        var list = await FindAll(x => x.PipelineHistories.Any(record => record.PipelineBuildState == PipelineBuildStateEnum.Running))
            .Include(x => x.PipelineHistories.Where(x => x.PipelineBuildState == PipelineBuildStateEnum.Running)).ToArrayAsync();
        return list;
    }
}