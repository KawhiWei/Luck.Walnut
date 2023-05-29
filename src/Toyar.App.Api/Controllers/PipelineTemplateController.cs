using Microsoft.AspNetCore.Mvc;
using Toyar.App.AppService.Pipelines;
using Toyar.App.AppService.PipelineTemplates;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Api.Controllers
{
    [Route("api/pipeline/templates")]
    [ApiController]
    public class PipelineTemplateController : BaseController
    {
        private readonly ILogger<PipelineTemplateController> _logger;

        public PipelineTemplateController(ILogger<PipelineTemplateController> logger)
        {
            _logger= logger;
        }

        /// <summary>
        /// 创建流水线
        /// </summary>
        /// <param name="pipelineService"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task CreateApplicationPipelineAsync([FromServices] IPipelineTemplateServices pipelineTemplateServices, [FromBody] PipelineTemplateInputDto input)
            => pipelineTemplateServices.CreatePipelineTemplateAsync(input);
    }
}
