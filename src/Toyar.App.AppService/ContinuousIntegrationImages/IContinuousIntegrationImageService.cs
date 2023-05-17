using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.AppService.ContinuousIntegrationImages
{
    public interface IContinuousIntegrationImageService : IScopedDependency
    {
        Task AddBuildImageAsync(ContinuousIntegrationImageInputDto input);

        Task DeleteBuildImageAsync(string id);

        Task UpdateBuildImageAsync(string id, ContinuousIntegrationImageInputDto input);

        Task CareatBuildImageVersion(ContinuousIntegrationImageVersionInputDto input);
    }
}
