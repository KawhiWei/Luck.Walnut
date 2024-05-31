using Toyar.Domain.AggregateRoots.ToyarEnvironments;

namespace Toyar.Domain.Repositories;

public interface IToyarEnvironmentRepository : IAggregateRootRepository<ToyarEnvironment, string>, IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="englishName"></param>
    /// <returns></returns>
    Task<ToyarEnvironment?> FindToyarEnvironmentByEnglishName(string englishName);


    Task<ToyarEnvironment?> FindToyarEnvironmentDetailByIdAsync(string id);
}