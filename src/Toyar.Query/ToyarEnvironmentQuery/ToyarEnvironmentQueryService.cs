using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.Repositories;

namespace Toyar.Query.ToyarEnvironmentQuery;


public class ToyarEnvironmentQueryService : IToyarEnvironmentQueryService
{
    private readonly IToyarEnvironmentRepository _toyarEnvironmentRepository;

    public ToyarEnvironmentQueryService(IToyarEnvironmentRepository toyarEnvironmentRepository)
    {
        _toyarEnvironmentRepository = toyarEnvironmentRepository;
    }

    public async Task<ToyarEnvironment?> FindToyarEnvironmentDetailForIdAsync(string id)
    {
        var toyarEnvironment = await _toyarEnvironmentRepository.FindToyarEnvironmentDetailByIdAsync(id);
        return toyarEnvironment;
    }
}