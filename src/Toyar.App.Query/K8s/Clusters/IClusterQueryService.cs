using Toyar.App.Dto;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.Query.K8s.Clusters
{
    public interface IClusterQueryService : IScopedDependency
    {

        Task<ClusterOutputDto> GetClusterByIdAsync(string id);


        Task<PageBaseResult<ClusterOutputDto>> GetClusterPageListAsync(ClusterQueryDto query);
    }
}
