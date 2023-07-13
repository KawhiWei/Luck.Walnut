using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Dto.Deployments;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Domain.Repositories;

public interface IDeploymentRepository : IAggregateRootRepository<Deployment, string>, IScopedDependency
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Deployment?> FirstOrDefaultByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<Deployment?> FirstOrDefaultByNameAsync(string name);


    /// <summary>
    /// 分页查询数据
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(Deployment[] Data, int TotalCount)> GetDeploymentPageListAsync(string appId, DeploymentQueryDto query);
}