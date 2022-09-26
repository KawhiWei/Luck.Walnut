using Luck.Walnut.Application.Applications;
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
        public Task AddApplication([FromBody] ApplicationInputDto input) => _applicationService.AddApplicationAsync(input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationQueryDto"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public Task<PageBaseResult<ApplicationOutputDto>> GetApplicationList([FromQuery] ApplicationQueryDto applicationQueryDto, [FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationListAsync(applicationQueryDto);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ApplicationOutputDto> GetApplicationDetailForId(string id,[FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationDetailForIdAsync(id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Task UpdateApplication(string id, [FromBody] ApplicationInputDto input) => _applicationService.UpdateApplicationAsync(id, input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteApplication(string id) => _applicationService.DeleteApplicationAsync(id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("enumlist")]
        public IEnumerable<KeyValuePair<string, string>> GetApplicationEnumList([FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationEnumList();

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("{appId}/dashboard")]
        public Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId,[FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationDashboardDetailAsync(appId);

    }
}