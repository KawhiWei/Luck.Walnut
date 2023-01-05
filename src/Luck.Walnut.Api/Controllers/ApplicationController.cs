using Luck.Walnut.Application.Applications;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Query.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class ApplicationController : BaseController
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly IApplicationService _applicationService;

        public ApplicationController(ILogger<ApplicationController> logger, IApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task CreateApplicationAsync([FromBody] ApplicationInputDto input) => _applicationService.AddApplicationAsync(input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationQueryDto"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public Task<PageBaseResult<ApplicationOutputDto>> GetApplicationListAsync([FromQuery] ApplicationQueryDto applicationQueryDto, [FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationPageListAsync(applicationQueryDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ApplicationOutput> GetApplicationDetailForIdAsync(string id, [FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationDetailForIdAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Task UpdateApplicationAsync(string id, [FromBody] ApplicationInputDto input) => _applicationService.UpdateApplicationAsync(id, input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteApplicationAsync(string id) => _applicationService.DeleteApplicationAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("language/list")]
        public IEnumerable<Language> GetLanguageList([FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetLanguageListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("{appId}/dashboard")]
        public Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId, [FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationDashboardDetailAsync(appId);

        /// <summary>
        /// 获取应用添加或者修改时所需要获取下拉框的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("selected/data")]
        public Task<ApplicationSeletedDataOutput> GetApplicationSelectedData([FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationSelectedDataAsync();
    }
}