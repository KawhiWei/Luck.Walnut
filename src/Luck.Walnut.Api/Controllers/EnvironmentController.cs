﻿using Luck.Framework.Utilities;
using Luck.Walnut.Application.Environments;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Dto.Environments;
using Luck.Walnut.Query;
using Luck.Walnut.Query.Applications;
using Luck.Walnut.Query.Environments;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers
{
    [Route("api/environment")]
    public class EnvironmentController : BaseController
    {
        private readonly IEnvironmentService _environmentService;

        public EnvironmentController(IEnvironmentService environmentService)
        {
            _environmentService = Check.NotNull(environmentService, nameof(environmentService));
        }

        /// <summary>
        /// 得到环境列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("{applicationId}/list")]
        public Task<List<AppEnvironmentListOutputDto>> GetApplicationDetailAndEnvironmentAsync(string applicationId,
            [FromServices] IApplicationQueryService applicationQueryService) =>
            applicationQueryService.GetEnvironmentAsync(applicationId);


        /// <summary>
        /// 添加环境
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task AddEnvironment([FromBody] AppEnvironmentInputDto input) => _environmentService.AddAppEnvironmentAsync(input);

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteEnvironment(string id) => _environmentService.DeleteAppEnvironmentAsync(id);


        /// <summary>
        /// 得到环境下配置列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("{environmentId}/config/list")]
        public Task<PageBaseResult<AppConfigurationOutputDto>> GetAppEnvironmentAndConfigurationPage(string environmentId, [FromQuery] PageBaseInputDto baseInputDto, [FromServices] IEnvironmentQueryService environmentQueryService) =>
            environmentQueryService.GetAppEnvironmentConfigurationPageAsync(environmentId, baseInputDto);


        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="environmentId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("{environmentId}/config")]
        public Task AddAppConfiguration(string environmentId, [FromBody] AppConfigurationInput input) => _environmentService.AddAppConfigurationAsync(environmentId, input);


        /// <summary>
        ///更新配置
        /// </summary>
        /// <param name="environmentId"></param>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{environmentId}/{id}/config")]
        public Task UpdageAppConfiguration(string environmentId, string id, [FromBody] AppConfigurationInput input) => _environmentService.UpdateAppConfigurationAsync(environmentId, id, input);

        /// <summary>
        /// 发布配置
        /// </summary>
        /// <param name="environmentId"></param>
        /// <param name="configrurationIds"></param>
        /// <returns></returns>
        [HttpPut("{environmentId}/publish")]
        public Task Publish(string environmentId, [FromBody] List<string> configrurationIds) => _environmentService.PublishAsync(environmentId, configrurationIds);

        /// <summary>
        /// 删除配置
        /// </summary>
        /// <param name="environmentId"></param>
        /// <param name="configurationId"></param>
        /// <returns></returns>
        [HttpDelete("{environmentId}/{configurationId}/config")]
        public Task DeleteAppConfiguration(string environmentId, string configurationId) => _environmentService.DeleteAppConfigurationAsync
            (environmentId, configurationId);

        /// <summary>
        /// 根据配置项id获取详情
        /// </summary>
        /// <param name="environmentQueryService"></param>
        /// <param name="configurationId"></param>
        /// <returns></returns>
        [HttpGet("{configurationId}/config")]
        public Task<AppConfigurationOutputDto> GetAppEnvironmentConfigurationDetail([FromServices] IEnvironmentQueryService environmentQueryService, string configurationId) => environmentQueryService.GetConfigurationDetailForConfigurationIdAsync(configurationId);

        /// <summary>
        /// 根据appId和EnvironmentName获取配置
        /// </summary>
        /// <param name="environmentQueryService"></param>
        /// <param name="appId"></param>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        [HttpGet("{appId}/{environmentName}/config")]
        public Task<AppEnvironmentOutputDto> GetAppConfigurationByAppIdAndEnvironmentName([FromServices] IEnvironmentQueryService environmentQueryService, string appId, string environmentName) => environmentQueryService.GetAppConfigurationByAppIdAndEnvironmentNameAsync(appId, environmentName);

        /// <summary>
        /// 获取环境下待发布配置列表
        /// </summary>
        /// <param name="environmentQueryService"></param>
        /// <param name="environmentId"></param>
        /// <param name="baseInputDto"></param>
        /// <returns></returns>
        [HttpGet("{environmentId}/not/publish/config/list")]
        public Task<PageBaseResult<AppEnvironmentPageListOutputDto>> GetToDontPublishAppConfiguration([FromServices] IEnvironmentQueryService environmentQueryService, string environmentId, [FromQuery] PageBaseInputDto baseInputDto) =>
            environmentQueryService.GetToDontPublishAppConfiguration(environmentId, baseInputDto);
    }
}