using Microsoft.AspNetCore.Mvc;

using Toyar.App.AppService.PipelineTemplates;
using Toyar.App.Dto.Applications;
using Toyar.App.Dto;
using Toyar.App.Dto.PipelineTemplates;
using Toyar.App.Query.Applications;
using Toyar.App.Query.PipelineTemplates;
using Toyar.App.Dto.ApplicationPipelines;

namespace Toyar.App.Api.Controllers
{
    [Route("api/pipeline/templates")]
    [ApiController]
    public class PipelineTemplateController : BaseController
    {
        private readonly ILogger<PipelineTemplateController> _logger;

        public PipelineTemplateController(ILogger<PipelineTemplateController> logger)
        {
            _logger = logger;
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

        /// <summary>
        /// 修改流水线
        /// </summary>
        /// <param name="pipelineTemplateServices"></param>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public Task UpdatePipelineTemplateAsync([FromServices] IPipelineTemplateServices pipelineTemplateServices, string id, [FromBody] PipelineTemplateInputDto input) => pipelineTemplateServices.UpdatePipelineTemplateAsync(id, input);

        /// <summary>
        /// 删除一个流水线
        /// </summary>
        /// <param name="pipelineTemplateServices"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeletePipelineTemplateAsync([FromServices] IPipelineTemplateServices pipelineTemplateServices, string id) => pipelineTemplateServices.DeletePipelineTemplateAsync(id);


        /// <summary>
        /// 获取一个流水线
        /// </summary>
        /// <param name="pipelineTemplateServices"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task GetPipelineTemplateByIdFirstOrDefault([FromServices] IPipelineTemplateQueryService pipelineTemplateQueryService, string id) => pipelineTemplateQueryService.GetPipelineTemplateByIdFirstOrDefaultAsync(id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationQueryDto"></param>
        /// <param name="applicationQueryService"></param>
        /// <returns></returns>
        [HttpGet("page")]
        public Task<PageBaseResult<PipelineOutputDto>> GetPipelineTemplatePageList([FromServices] IPipelineTemplateQueryService pipelineTemplateQueryService, [FromQuery] PipelineTemplateQueryDto queryDto) => pipelineTemplateQueryService.GetPipelineTemplatePageListAsync(queryDto);

    }
}
