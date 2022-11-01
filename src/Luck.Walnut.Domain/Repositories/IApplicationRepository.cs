using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Dto.Applications;

namespace Luck.Walnut.Domain.Repositories;


public interface IApplicationRepository : IAggregateRootRepository<Application,string>,IScopedDependency
{
    Task<Application?> FindFirstOrDefaultByIdAsync(string id);

    Task<Application?> FindFirstOrDefaultByAppIdAsync(string appId);

    Task<(ApplicationOutputDto[] Data, int TotalCount)> GetApplicationPageListAsync(ApplicationQueryDto query);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="appId"></param>
    /// <returns></returns>
    Task<ApplicationOutputDto> FindFirstOrDefaultOutputDtoByAppIdAsync(string appId);
}