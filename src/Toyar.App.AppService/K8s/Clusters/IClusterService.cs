using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.AppService.K8s.Clusters
{
    public interface IClusterService : IScopedDependency
    {

        /// <summary>
        /// 创建集群
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateClusterAsync(ClusterInputDto input);

        /// <summary>
        /// 修改集群
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateClusterAsync(string id, ClusterInputDto input);


        /// <summary>
        /// 删除集群
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteClusterAsync(string id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Cluster> CheckAndGetCluster(string id);
    }
}
