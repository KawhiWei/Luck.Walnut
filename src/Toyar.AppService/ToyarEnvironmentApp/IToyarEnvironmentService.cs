using Toyar.Dto.ToyarEnvironments;

namespace Toyar.AppService.ToyarEnvironmentApp;

public interface IToyarEnvironmentService : IScopedDependency
{
    Task CreateToyarEnvironmentAsync(ToyarEnvironmentInputDto input);

    Task DeleteToyarEnvironmentByIdAsync(string id);
}