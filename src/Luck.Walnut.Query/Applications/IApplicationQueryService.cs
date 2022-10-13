using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Dto.Environments;

namespace Luck.Walnut.Query.Applications
{
    public interface IApplicationQueryService : IScopedDependency
    {
        /// <summary>
        /// 获取应用列表
        /// </summary>
        /// <returns></returns>
        Task<PageBaseResult<ApplicationOutputDto>> GetApplicationListAsync(ApplicationQueryDto query);

        /// <summary>
        /// 获取应用和环境列表
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<List<AppEnvironmentListOutputDto>> GetEnvironmentAsync(string appId);

        /// <summary>
        /// 根据主机获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationOutputDto?> GetApplicationDetailForIdAsync(string id);


        /// <summary>
        /// 获取应用状态枚举
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> GetApplicationEnumList();

        /// <summary>
        /// 获取应用仪表盘明细信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId);

        
        /// <summary>
        /// 获取语言列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<Language> GetLanguageListAsync();
    }
}