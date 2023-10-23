using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Dto.K8s.WorkLoads;

namespace Toyar.App.Domain.Repositories;

public interface IWorkLoadRepository : IAggregateRootRepository<WorkLoad, string>, IScopedDependency
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<WorkLoad?> FirstOrDefaultByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<WorkLoad?> FirstOrDefaultByNameAsync(string name);


    /// <summary>
    /// 分页查询数据
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(WorkLoad[] Data, int TotalCount)> GetDeploymentPageListAsync(string appId, WorkLoadQueryDto query);
}