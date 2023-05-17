using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Domain.Repositories;

public interface IEnvironmentRepository : IAggregateRootRepository<AppEnvironment,string>,IScopedDependency
{

    Task<AppEnvironment?> FirstOrDefaultByIdAsync(string id);
    
    Task<AppEnvironment?> FirstOrDefaultByEnvironmentNameAsync(string environmentName);

    /// <summary>
    /// 获取环境列表
    /// </summary>
    /// <param name="appId"></param>
    /// <returns></returns>
    Task<List<AppEnvironmentListOutputDto>> GetEnvironmentListForApplicationId(string appId);
    /// <summary>
    /// 获取配置列表
    /// </summary>
    /// <param name="environmentId"></param>
    /// <param name="baseInputDto"></param>
    /// <returns></returns>
    Task<PageBaseResult<AppConfigurationOutputDto>> GetAppConfigurationPageAsync(string environmentId, PageBaseInputDto baseInputDto);

}