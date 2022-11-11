using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Repositories;

public class ApplicationPipelineRepository : EfCoreAggregateRootRepository<ApplicationPipeline, string>, IApplicationPipelineRepository
{
    public ApplicationPipelineRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<ApplicationPipeline> FindFirstByIdAsync(string id)
    {
        var componentIntegration = await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if (componentIntegration is null)
            throw new BusinessException($"组件集成流水线不存在");
        return componentIntegration;
    }


    public async Task<(ApplicationPipelineOutputDto[] Data, int TotalCount)> GetApplicationPipelinePageListAsync(string appId, ApplicationPipelineQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
            .WhereIf(x => x.Published == query.Published, query.Published.HasValue)
            .WhereIf(x => x.PipelineState == query.PipelineStatus, query.PipelineStatus.HasValue);

        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var outputList = list.Select(x => new ApplicationPipelineOutputDto
        {
            Id = x.Id,
            Name = x.Name,
            PipelineState = x.PipelineState,
            Published = x.Published,
            AppEnvironmentId = x.AppEnvironmentId,
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
}