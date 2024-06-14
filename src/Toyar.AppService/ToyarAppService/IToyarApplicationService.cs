using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

public interface IToyarApplicationService : IScopedDependency
{
    Task CreateToyarApplicationAsync(ToyarApplicationInputDto input);

    Task DeleteToyarAppByIdAsync(string id);

    Task AddToyarApplicationUserRelationAsync(string appId, ToyarApplicationPermissionRelationInputDto input);

    Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId);
}