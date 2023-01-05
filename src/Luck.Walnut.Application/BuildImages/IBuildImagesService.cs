using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Application.BuildImages
{
    public interface IBuildImagesService : IScopedDependency
    {
        Task AddBuildImageAsync(BuildImagesInputDto input);

        Task DeleteBuildImageAsync(string id);

        Task UpdateBuildImageAsync(string id, BuildImagesInputDto input);
    }
}
