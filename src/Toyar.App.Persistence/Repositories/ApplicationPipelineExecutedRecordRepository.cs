using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Persistence.Repositories;

public class ApplicationPipelineExecutedRecordRepository : EfCoreEntityRepository<PipelineHistory, string>, IApplicationPipelineExecutedRecordRepository
{
    public ApplicationPipelineExecutedRecordRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(ApplicationPipelineExecutedRecordOutputDto[] Data, int TotalCount)> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query)
    {
        var queryable = FindAll(x => x.PipelineId == applicationPipelineId)
            .WhereIf(x => x.PipelineBuildState == query.PipelineBuildState, query.PipelineBuildState.HasValue);

        var list = await queryable.OrderByDescending(x=>x.CreationTime).ToPage(query.PageIndex, query.PageSize)
            
            .Select(row => new ApplicationPipelineExecutedRecordOutputDto
            {
                Id = row.Id,
                ApplicationPipelineId = row.PipelineId,
                JenkinsBuildNumber = row.JenkinsBuildNumber,
                PipelineBuildState = row.PipelineBuildState,
                ImageVersion = row.ImageVersion,
            }).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }

    public async Task<PipelineHistory> FindFirstByIdAsync(string id)
    {
        var applicationPipelineExecutedRecord = await FindAll().FirstOrDefaultAsync(x => x.Id == id);
        if (applicationPipelineExecutedRecord is null)
        {
            throw new BusinessException($"执行记录不存在");
        }
        return applicationPipelineExecutedRecord;
    }

    public async Task<PipelineHistory[]> GetRunningApplicationPipelineExecutedRecordListAsync()
    {
        var list = await FindAll(x => x.PipelineBuildState == PipelineBuildStateEnum.Running).ToArrayAsync();
        return list;
    }

    public async Task<PipelineHistory[]> GetApplicationPipelineExecutedRecordListAsync(IEnumerable<string> applicationPipelineList)
    {
        var list = await FindAll(x => applicationPipelineList.Contains(x.PipelineId)).ToArrayAsync();
        return list;
    }
}