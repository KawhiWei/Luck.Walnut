using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.Query.K8s.Clusters
{
    public class ClusterQueryService : IClusterQueryService
    {
        private readonly IClusterRepository _clusterRepository;
        public ClusterQueryService(IClusterRepository clusterRepository)
        {
            _clusterRepository = clusterRepository;
        }

        public async Task<ClusterOutputDto> GetClusterByIdAsync(string id)
        {
            var cluster = await CheckAndGetCluster(id);
            return StructureClusterOutputDto(cluster);
        }

        public async Task<PageBaseResult<ClusterOutputDto>> GetClusterPageListAsync(ClusterQueryDto query)
        {
            var result = await _clusterRepository.GetClusterPageListAsync(query);
            return new PageBaseResult<ClusterOutputDto>(result.TotalCount, result.Data.Select(cluster => StructureClusterOutputDto(cluster)).ToArray());

        }


        public async Task<List<ClusterOutputDto>> GetClusterListAsync()
        {
            var result = await _clusterRepository.GetClusterListAsync();
            return result.Select(cluster => StructureClusterOutputDto(cluster)).ToList();

        }

        private async Task<Cluster> CheckAndGetCluster(string id)
        {
            var cluster = await _clusterRepository.FirstOrDefaultByIdAsync(id);
            return cluster is null ? throw new BusinessException($"集群不存在") : cluster;
        }

        private static ClusterOutputDto StructureClusterOutputDto(Cluster cluster)
        {
            return new ClusterOutputDto
            {
                Id = cluster.Id,
                Name = cluster.Name,
                Config = cluster.Config,
                ClusterVersion = cluster.ClusterVersion
            };

        }

    }
}
