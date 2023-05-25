using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PipelineTemplateController : BaseController
    {
        private readonly ILogger<PipelineTemplateController> _logger;

        public PipelineTemplateController(ILogger<PipelineTemplateController> logger)
        {
            _logger= logger;
        }
    }
}
