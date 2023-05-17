using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Query.Environments
{
    public interface IEnvironmentQueryService : IScopedDependency
    {
        /// <summary>
        /// 根据应用Id和环境名称获取配置列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        Task<AppEnvironmentOutputDto> GetAppConfigurationByAppIdAndEnvironmentNameAsync(string appId, string environmentName);
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        Task<PageBaseResult<AppConfigurationOutputDto>> GetAppEnvironmentConfigurationPageAsync(string environmentId, PageBaseInputDto baseInputDto);
        /// <summary>
        /// 根据配置项id获取详情
        /// </summary>
        /// <param name="configurationId"></param>
        /// <returns></returns>
        Task<AppConfigurationOutputDto> GetConfigurationDetailForConfigurationIdAsync(string configurationId);

        /// <summary>
        /// 获取待发布的配置项
        /// </summary>
        /// <param name="environmentId"></param>
        /// <param name="baseInputDto"></param>
        /// <returns></returns>
        Task<PageBaseResult<AppEnvironmentPageListOutputDto>> GetToDontPublishAppConfiguration(string environmentId, PageBaseInputDto baseInputDto);

    }
}
