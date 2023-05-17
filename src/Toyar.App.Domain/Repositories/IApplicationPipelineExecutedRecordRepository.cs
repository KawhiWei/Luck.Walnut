using Toyar.App.Domain.AggregateRoots.Pipelines;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Domain.Repositories;

public interface IApplicationPipelineExecutedRecordRepository:IEntityRepository<PipelineHistory,string>,IScopedDependency
{
    
    /// <summary>
    /// 根据流水线Id分页获取执行记录
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ApplicationPipelineExecutedRecordOutputDto[] Data, int TotalCount)> GetApplicationPipelineExecutedRecordPageListAsync(string applicationPipelineId, ApplicationPipelineExecutedQueryDto query);

    Task<PipelineHistory> FindFirstByIdAsync(string id);
    
    /// <summary>
    /// 获取运行中的执行记录
    /// </summary>
    /// <returns></returns>
    Task<PipelineHistory[]> GetRunningApplicationPipelineExecutedRecordListAsync();


    Task<PipelineHistory[]> GetApplicationPipelineExecutedRecordListAsync(IEnumerable<string> applicationPipelineList);
}