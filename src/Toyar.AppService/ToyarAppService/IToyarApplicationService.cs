using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

public interface IToyarApplicationService : IScopedDependency
{
    Task CreateToyarAppAsync(ToyarAppInputDto input);
    
    
    Task DeleteToyarAppByIdAsync(string id);
}