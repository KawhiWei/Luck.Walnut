using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Persistence.Repositories;

public class ApplicationPipelineHistoryRepository : EfCoreEntityRepository<ApplicationPipelineHistory, string>, IApplicationPipelineHistoryRepository
{
    public ApplicationPipelineHistoryRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(ApplicationPipelineHistory[] Data, int TotalCount)> GetApplicationPipelineHistoryByPipeLineIdPageListAsync(string applicationPipelineId, ApplicationPipelineHistoryQueryDto query)
    {
        var queryable = FindAll(x => x.PipelineId == applicationPipelineId)
            .WhereIf(x => x.PipelineBuildState == query.PipelineBuildState, query.PipelineBuildState.HasValue);

        var list = await queryable.OrderByDescending(x=>x.CreationTime).ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }

    public async Task<(ApplicationPipelineHistory[] Data, int TotalCount)> GetPipelineHistoryForAppIdPageListAsync(string appId, ApplicationPipelineHistoryQueryDto query)
    {
        var queryable = FindAll(x => x.AppId ==appId )
            .WhereIf(x => x.PipelineBuildState == query.PipelineBuildState, query.PipelineBuildState.HasValue);

        var list = await queryable.OrderByDescending(x=>x.CreationTime).ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }

   
    public async Task<ApplicationPipelineHistory> FindFirstByIdAsync(string id)
    {
        var applicationPipelineExecutedRecord = await FindAll().FirstOrDefaultAsync(x => x.Id == id);
        if (applicationPipelineExecutedRecord is null)
        {
            throw new BusinessException($"执行记录不存在");
        }
        return applicationPipelineExecutedRecord;
    }

    public async Task<ApplicationPipelineHistory[]> GetRunningApplicationPipelineExecutedRecordListAsync()
    {
        var list = await FindAll(x => x.PipelineBuildState == PipelineBuildStateEnum.Running).ToArrayAsync();
        return list;
    }

    public async Task<ApplicationPipelineHistory[]> GetApplicationPipelineExecutedRecordListAsync(IEnumerable<string> applicationPipelineList)
    {
        var list = await FindAll(x => applicationPipelineList.Contains(x.PipelineId)).ToArrayAsync();
        return list;
    }
    
}