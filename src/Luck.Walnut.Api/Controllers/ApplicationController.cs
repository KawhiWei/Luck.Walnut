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

        [HttpPost]
        public Task AddApplication([FromBody] ApplicationInputDto input) => _applicationService.AddApplicationAsync(input);

        [HttpGet("page")]
        public Task<PageBaseResult<ApplicationOutputDto>> GetApplicationList([FromQuery] PageBaseInputDto baseInputDto, [FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationListAsync(baseInputDto);

        [HttpGet("{id}")]
        public Task<ApplicationDetailOutputDto> GetApplicationDetailForId(string id,[FromServices] IApplicationQueryService applicationQueryService) => applicationQueryService.GetApplicationDetailForIdAsync(id);

        [HttpPut("{id}")]
        public Task UpdateApplication(string id, [FromBody] ApplicationInputDto input) => _applicationService.UpdateApplicationAsync(id, input);

        [HttpDelete("{id}")]
        public Task DeleteApplication(string id) => _applicationService.DeleteApplicationAsync(id);

    }
}