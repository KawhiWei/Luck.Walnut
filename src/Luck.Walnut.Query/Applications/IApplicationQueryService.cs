﻿using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;

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
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationOutput> GetApplicationDetailAndEnvironmentAsync(string id);

        /// <summary>
        /// 根据业务唯一编码获取
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<ApplicationDetailOutputDto> GetApplicationDetailForAppIdAsync(string appId);
        
        
        /// <summary>
        /// 根据主机获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApplicationDetailOutputDto> GetApplicationDetailForIdAsync(string id);


        /// <summary>
        /// 获取应用状态枚举
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> GetApplicationEnumList();
    }
}
