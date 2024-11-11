using Toyar.Dto.ToyarApplications;

namespace Toyar.AppService.ToyarApplicationService;

public interface IToyarApplicationService : IScopedDependency
{
    Task AddToyarApplicationAsync(ToyarCreateApplicationInputDto input);

    Task DeleteToyarAppByIdAsync(string appId);

    Task AddToyarApplicationPermissionRelationAsync(string appId, ToyarApplicationPermissionRelationInputDto input);

    Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId);

    Task AddToyarApplicationEnvironmentRelationAsync(string appId, ToyarApplicationEnvironmentRelationInputDto input);
    
    Task AddToyarApplicationDeploymentConfigurationAsync(string appId,
        ToyarApplicationDeploymentConfigurationInputDto input);

    Task UpdateToyarApplicationDeploymentConfigurationAsync(string appId, string id,
        ToyarApplicationDeploymentConfigurationInputDto input);
}