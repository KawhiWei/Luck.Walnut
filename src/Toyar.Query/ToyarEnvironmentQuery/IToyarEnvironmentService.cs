using Toyar.Domain.AggregateRoots.ToyarEnvironments;

namespace Toyar.Query.ToyarEnvironmentQuery;

public interface IToyarEnvironmentQueryService : IScopedDependency
{
    Task<ToyarEnvironment?> FindEnvironmentDetailForIdAsync(string id);
}