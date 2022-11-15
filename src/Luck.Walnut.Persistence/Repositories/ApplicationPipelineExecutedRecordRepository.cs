using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Persistence.Repositories;

public class ApplicationPipelineExecutedRecordRepository : EfCoreEntityRepository<ApplicationPipelineExecutedRecord, string>, IApplicationPipelineExecutedRecordRepository
{
    public ApplicationPipelineExecutedRecordRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(ApplicationPipelineExecutedRecordOutputDto[] Data, int TotalCount)> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query)
    {
        var queryable = FindAll(x => x.ApplicationPipelineId == applicationPipelineId)
            .WhereIf(x => x.PipelineBuildState == query.PipelineBuildState, query.PipelineBuildState.HasValue);

        var list = await queryable.OrderByDescending(x=>x.CreationTime).ToPage(query.PageIndex, query.PageSize)
            
            .Select(row => new ApplicationPipelineExecutedRecordOutputDto
            {
                Id = row.Id,
                ApplicationPipelineId = row.ApplicationPipelineId,
                JenkinsBuildNumber = row.JenkinsBuildNumber,
                PipelineBuildState = row.PipelineBuildState,
                ImageVersion = row.ImageVersion,
                BuildLogs = row.BuildLogs,
            }).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }

    public async Task<ApplicationPipelineExecutedRecord> FindFirstByIdAsync(string id)
    {
        var applicationPipelineExecutedRecord = await FindAll().FirstOrDefaultAsync(x => x.Id == id);
        if (applicationPipelineExecutedRecord is null)
        {
            throw new BusinessException($"执行记录不存在");
        }
        return applicationPipelineExecutedRecord;
    }

    public async Task<ApplicationPipelineExecutedRecord[]> GetRunningApplicationPipelineExecutedRecordListAsync()
    {
        var list = await FindAll(x => x.PipelineBuildState == PipelineBuildStateEnum.Running).ToArrayAsync();
        return list;
    }
}