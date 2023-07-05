using Toyar.App.Dto;
using Toyar.App.Dto.Applications;

namespace Toyar.App.Query.Applications
{
    public interface IApplicationQueryService : IScopedDependency
    {
        /// <summary>
        /// 获取应用列表
        /// </summary>
        /// <returns></returns>
        Task<PageBaseResult<ApplicationOutputDto>> GetApplicationPageListAsync(ApplicationQueryDto query);

        /// <summary>
        /// 根据主机获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationOutputDto?> GetApplicationDetailForIdAsync(string id);

        /// <summary>
        /// 获取应用仪表盘明细信息
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId);

        /// <summary>
        /// 获取应用添加或者修改时所需要获取下拉框的数据
        /// </summary>
        /// <returns></returns>
        Task<ApplicationSeletedDataOutput> GetApplicationSelectedDataAsync();
    }
}