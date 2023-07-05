using Luck.Framework.Utilities;
using Toyar.App.AppService.Environments;
using Toyar.App.Dto;
using Toyar.App.Dto.Applications;
using Toyar.App.Dto.Environments;
using Toyar.App.Query;
using Toyar.App.Query.Applications;
using Toyar.App.Query.Environments;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers
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
        /// 添加环境
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task AddEnvironment([FromBody] AppEnvironmentInputDto input) => _environmentService.CreateEnvironmentAsync(input);

        /// <summary>
        /// 删除环境
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task DeleteEnvironment(string id) => _environmentService.DeleteEnvironmentAsync(id);

    }
}