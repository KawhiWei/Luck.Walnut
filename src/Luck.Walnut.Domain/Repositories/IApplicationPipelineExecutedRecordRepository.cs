using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Dto.ApplicationPipelines;

namespace Luck.Walnut.Domain.Repositories;

public interface IApplicationPipelineExecutedRecordRepository:IEntityRepository<ApplicationPipelineExecutedRecord,string>,IScopedDependency
{
    
    /// <summary>
    /// 根据流水线Id分页获取执行记录
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ApplicationPipelineExecutedRecordOutputDto[] Data, int TotalCount)> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query);

    Task<ApplicationPipelineExecutedRecord> FindFirstByIdAsync(string id);
    
    /// <summary>
    /// 获取运行中的执行记录
    /// </summary>
    /// <returns></returns>
    Task<ApplicationPipelineExecutedRecord[]> GetRunningApplicationPipelineExecutedRecordListAsync();


    Task<ApplicationPipelineExecutedRecord[]> GetApplicationPipelineExecutedRecordListAsync(IEnumerable<string> applicationPipelineList);
}