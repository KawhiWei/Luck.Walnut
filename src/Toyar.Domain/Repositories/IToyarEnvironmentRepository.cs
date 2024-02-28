using Toyar.Domain.AggregateRoots.Environments;

namespace Toyar.Domain.Repositories;

public interface IToyarEnvironmentRepository : IAggregateRootRepository<ToyarEnvironment, string>, IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<ToyarEnvironment?> FindToyarEnvironmentByName(string name);
}