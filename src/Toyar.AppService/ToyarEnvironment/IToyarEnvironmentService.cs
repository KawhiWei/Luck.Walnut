using Toyar.Dto.Environments;

namespace Toyar.AppService.ToyarEnvironment;

public interface IToyarEnvironmentService : IScopedDependency
{
    Task CreateToyarEnvironmentAsync(ToyarEnvironmentInputDto input);

    Task DeleteToyarEnvironmentByIdAsync(string id);
}