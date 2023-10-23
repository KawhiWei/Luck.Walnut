using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.Domain.Repositories;

public interface IClusterRepository : IAggregateRootRepository<Cluster, string>, IScopedDependency
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Cluster?> FirstOrDefaultByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<List<Cluster>> GetClusterByIdListAsync(List<string> idList);


    /// <summary>
    /// 分页获取集群列表
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(Cluster[] Data, int TotalCount)> GetClusterPageListAsync(ClusterQueryDto query);

    Task<List<Cluster>> GetClusterListAsync();
}