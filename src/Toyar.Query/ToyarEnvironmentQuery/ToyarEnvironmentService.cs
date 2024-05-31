using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.Repositories;

namespace Toyar.Query.ToyarEnvironmentQuery;

public class ToyarEnvironmentQueryService : IToyarEnvironmentQueryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToyarEnvironmentRepository _toyarEnvironmentRepository;

    public ToyarEnvironmentQueryService(IUnitOfWork unitOfWork, IToyarEnvironmentRepository toyarEnvironmentRepository)
    {
        _unitOfWork = unitOfWork;
        _toyarEnvironmentRepository = toyarEnvironmentRepository;
    }
    public async Task<ToyarEnvironment?> FindToyarEnvironmentDetailForIdAsync(string id)
    {
        var toyarEnvironment = await _toyarEnvironmentRepository.FindToyarEnvironmentDetailByIdAsync(id);
        return toyarEnvironment;
    }
}