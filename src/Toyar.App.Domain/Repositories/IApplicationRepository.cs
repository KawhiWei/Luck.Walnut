using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Dto.Applications;

namespace Toyar.App.Domain.Repositories;


public interface IApplicationRepository : IAggregateRootRepository<Application, string>,IScopedDependency
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