using Luck.Framework.Utilities;
using Toyar.App.AppService.Environments;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;
using Toyar.App.Query.Environments;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers
{
    [Route("api/environments")]
    public class ToyarEnvironmentController : BaseController
    {
        private readonly IToyarEnvironmentService _environmentService;

        public ToyarEnvironmentController(IToyarEnvironmentService environmentService)
        {
            _environmentService = Check.NotNull(environmentService, nameof(environmentService));
        }

        /// <summary>
        /// 添加环境
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task AddEnvironment([FromBody] ToyarEnvironmentInputDto input) => _environmentService.CreateEnvironmentAsync(input);

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteEnvironment(string id) => _environmentService.DeleteEnvironmentAsync(id);

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("page/list")]
        public Task<PageBaseResult<ToyarEnvironmentOutputDto>> GetEnvironmentPageListAsync([FromServices] IToyarEnvironmentQueryService toyarEnvironmentQueryService, [FromQuery] ToyarEnvironmentQueryDto query) => toyarEnvironmentQueryService.GetEnvironmentPageListAsync(query);


        /// <summary>
        /// 根据Id获取一个环境详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Task<ToyarEnvironmentOutputDto> GetEnvironmentDetailForIdAsync([FromServices] IToyarEnvironmentQueryService toyarEnvironmentQueryService, string id) => toyarEnvironmentQueryService.GetEnvironmentDetailForIdAsync(id);

    }
}