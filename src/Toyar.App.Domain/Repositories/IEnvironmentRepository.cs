using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Domain.Repositories;

public interface IEnvironmentRepository : IAggregateRootRepository<AppEnvironment, string>, IScopedDependency
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AppEnvironment?> FirstOrDefaultByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<AppEnvironment?> FirstOrDefaultByEnvironmentNameAsync(string name);
}