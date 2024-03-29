using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Dto.ApplicationPipelines;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Domain.Repositories;

public interface IApplicationPipelineRepository : IAggregateRootRepository<ApplicationPipeline, string>, IScopedDependency
{
    
    /// <summary>
    /// 根据Id查询一个流水线
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ApplicationPipeline> FindFirstByIdAsync(string id);


    /// <summary>
    /// 分页查询流水线
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ApplicationPipelineOutputDto[] Data, int TotalCount)> GetApplicationPipelinePageListAsync(string appId, ApplicationPipelineQueryDto query);

    /// <summary>
    /// 查询运行记录有存在运行状态的所有流水线和运行状态的运行记录
    /// </summary>
    /// <returns></returns>
    Task<ApplicationPipeline[]> GetRunningApplicationPipelineAsync();
}