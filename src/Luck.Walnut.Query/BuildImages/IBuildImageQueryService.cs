using Luck.Walnut.Dto;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Query.BuildImages
{
    public interface IBuildImageQueryService : IScopedDependency
    {
        Task<List<BuildImagesOutputDto>> GetBuildImages();

        Task<PageBaseResult<BuildImagesOutputDto>> GetBuildImagesPageList(BuildImagesQueryDto query);

        Task<BuildImagesOutputDto> GetBuildImagesPageById(string id);
    }
}
