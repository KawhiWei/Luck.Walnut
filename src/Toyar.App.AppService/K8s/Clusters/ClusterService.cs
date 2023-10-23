using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.AppService.K8s.Clusters
{
    public class ClusterService : IClusterService
    {
        private readonly IClusterRepository _clusterRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClusterService(IClusterRepository clusterRepository, IUnitOfWork unitOfWork)
        {
            _clusterRepository = clusterRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task CreateClusterAsync(ClusterInputDto input)
        {
            var cluster = new Cluster(input.Name, input.Config, input.ClusterVersion);
            _clusterRepository.Add(cluster);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateClusterAsync(string id, ClusterInputDto input)
        {

            var cluster = await CheckAndGetCluster(id);
            cluster.SetClusterVersion(input.ClusterVersion).SetConfig(input.Config).SetName(input.Name);
            await _unitOfWork.CommitAsync();
        }



        public async Task DeleteClusterAsync(string id)
        {
            var cluster = await CheckAndGetCluster(id);
            _clusterRepository.Remove(cluster);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Cluster> CheckAndGetCluster(string id)
        {
            var cluster = await _clusterRepository.FirstOrDefaultByIdAsync(id);
            return cluster is null ? throw new BusinessException($"集群不存在") : cluster;
        }

    }
}
