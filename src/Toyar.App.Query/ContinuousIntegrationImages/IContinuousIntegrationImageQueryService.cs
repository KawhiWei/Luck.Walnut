using Toyar.App.Dto;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Query.ContinuousIntegrationImages
{
    public interface IContinuousIntegrationImageQueryService : IScopedDependency
    {
        Task<List<ContinuousIntegrationImageOutputDto>> GetBuildImages();

        Task<PageBaseResult<ContinuousIntegrationImageOutputDto>> GetBuildImagesPageList(ContinuousIntegrationImagesQueryDto query);

        Task<ContinuousIntegrationImageOutputDto> GetBuildImagesPageById(string id);
    }
}
