using Microsoft.AspNetCore.Mvc;
using Toyar.App.AppService.Deployments;
using Toyar.App.Dto;
using Toyar.App.Dto.Deployments;
using Toyar.App.Query.Deployments;

namespace Toyar.App.Api.Controllers;

[Route("api/deployments")]
public class DeploymentController : BaseController
{

    /// <summary>
    /// 创建一个部署
    /// </summary>
    /// <param name="deploymentService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task CreateDeploymentAsync([FromServices] IDeploymentService deploymentService, [FromBody] DeploymentInputDto input) => deploymentService.CreateDeploymentAsync(input);

    /// <summary>
    /// 修改部署
    /// </summary>
    /// <param name="deploymentService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateDeploymentAsync([FromServices] IDeploymentService deploymentService, string id, [FromBody] DeploymentInputDto input) => deploymentService.UpdateDeploymentAsync(id, input);


    /// <summary>
    /// 删除部署
    /// </summary>
    /// <param name="deploymentService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteDeploymentAsync([FromServices] IDeploymentService deploymentService, string id) => deploymentService.DeleteDeploymentAsync(id);


    /// <summary>
    /// 修改部署
    /// </summary>
    /// <param name="deploymentService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<DeploymentOutputDto> GetDeploymentForIdAsync([FromServices] IDeploymentQueryService deploymentQueryService, string id) => deploymentQueryService.GetDeploymentForIdAsync(id);

    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="deploymentQueryService"></param>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("{appId}/page/list")]
    public Task<PageBaseResult<DeploymentOutputDto>> GetDeploymentPageListAsync([FromServices] IDeploymentQueryService deploymentQueryService, string appId, DeploymentQueryDto query) => deploymentQueryService.GetDeploymentPageListAsync(appId, query);

}
