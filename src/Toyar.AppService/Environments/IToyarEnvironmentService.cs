using Toyar.Dto.Environments;

namespace Toyar.AppService.Environments;

public interface IToyarEnvironmentService : IScopedDependency
{
    Task CreateToyarEnvironmentAsync(ToyarEnvironmentInputDto input);

    Task DeleteToyarEnvironmentByIdAsync(string id);
}