using Toyar.Dto.ToyarEnvironments;

namespace Toyar.AppService.ToyarEnvironmentService;

public interface IToyarEnvironmentService : IScopedDependency
{
    Task CreateToyarEnvironmentAsync(ToyarEnvironmentInputDto input);

    Task DeleteToyarEnvironmentByIdAsync(string id);
}