using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

public interface IToyarAppService : IScopedDependency
{
    Task CreateToyarAppAsync(ToyarAppInputDto input);
    
    
    Task DeleteToyarAppByIdAsync(string id);
}