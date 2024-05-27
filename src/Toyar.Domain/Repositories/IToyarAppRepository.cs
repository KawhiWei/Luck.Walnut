using Toyar.Domain.AggregateRoots.ToyarApps;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;

namespace Toyar.Domain.Repositories;

public interface IToyarAppRepository : IAggregateRootRepository<ToyarApp, string>, IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="isInclude"></param>
    /// <returns></returns>
    Task<ToyarApp?> FindToyarAppByAppId(string appId,bool isInclude);

    
    Task<ToyarApp?> FindToyarAppById(string id, bool isInclude);
}