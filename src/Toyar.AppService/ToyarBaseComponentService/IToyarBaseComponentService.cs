using Toyar.Dto.ToyarBaseComponents;

namespace Toyar.AppService.ToyarBaseComponentService;

public interface IToyarBaseComponentService : IScopedDependency
{
    Task AddToyarBaseComponentAsync(ToyarBaseComponentInput input);
}