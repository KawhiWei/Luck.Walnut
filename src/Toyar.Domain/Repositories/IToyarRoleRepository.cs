using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.AggregateRoots.ToyarRoles;

namespace Toyar.Domain.Repositories;

public interface IToyarRoleRepository : IAggregateRootRepository<ToyarRole, string>, IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="englishName"></param>
    /// <returns></returns>
    Task<ToyarRole?> FindToyarRoleByEnglishNameAsync(string englishName);
}