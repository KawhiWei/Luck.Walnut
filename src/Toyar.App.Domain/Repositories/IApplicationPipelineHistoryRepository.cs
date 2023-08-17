using Toyar.App.Domain.AggregateRoots.ApplicationPipelines;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Domain.Repositories;

public interface IApplicationPipelineHistoryRepository:IEntityRepository<ApplicationPipelineHistory,string>,IScopedDependency
{
    
    /// <summary>
    /// 根据流水线Id分页获取执行记录
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ApplicationPipelineExecutedRecordOutputDto[] Data, int TotalCount)> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query);

    Task<ApplicationPipelineHistory> FindFirstByIdAsync(string id);
    
    /// <summary>
    /// 获取运行中的执行记录
    /// </summary>
    /// <returns></returns>
    Task<ApplicationPipelineHistory[]> GetRunningApplicationPipelineExecutedRecordListAsync();


    Task<ApplicationPipelineHistory[]> GetApplicationPipelineExecutedRecordListAsync(IEnumerable<string> applicationPipelineList);
}