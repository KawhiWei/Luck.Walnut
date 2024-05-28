using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;

namespace Toyar.Domain.Repositories;

public interface IToyarApplicationRepository : IAggregateRootRepository<ToyarApplication, string>, IScopedDependency
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="isInclude"></param>
    /// <returns></returns>
    Task<ToyarApplication?> FindToyarAppByAppId(string appId,bool isInclude);

    
    Task<ToyarApplication?> FindToyarAppById(string id, bool isInclude);
}