using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarApplicationService;

public interface IToyarApplicationService : IScopedDependency
{
    Task AddToyarApplicationAsync(ToyarApplicationInputDto input);

    Task DeleteToyarAppByIdAsync(string appId);

    Task AddToyarApplicationPermissionRelationAsync(string appId, ToyarApplicationPermissionRelationInputDto input);

    Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId);

    Task AddToyarApplicationEnvironmentRelationAsync(string appId, ToyarApplicationEnvironmentRelationInputDto input);
}