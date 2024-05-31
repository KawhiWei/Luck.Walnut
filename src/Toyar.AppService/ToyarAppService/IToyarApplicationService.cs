using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

public interface IToyarApplicationService : IScopedDependency
{
    Task CreateToyarApplicationAsync(ToyarApplicationInputDto input);
    
    
    Task DeleteToyarAppByIdAsync(string id);
}