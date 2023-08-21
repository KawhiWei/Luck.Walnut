using Microsoft.AspNetCore.Mvc;
using Toyar.App.AppService.K8s.WorkLoads;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.WorkLoads;
using Toyar.App.Query.K8s.WorkLoads;

namespace Toyar.App.Api.Controllers;

[Route("api/workloads")]
public class WorkLoadController : BaseController
{

    /// <summary>
    /// 创建部署
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task CreateWorkLoadAsync([FromServices] IWorkLoadService workLoadService, [FromBody] WorkLoadInputDto input) => workLoadService.CreateWorkLoadAsync(input);

    /// <summary>
    /// 修改部署
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateWorkLoadAsync([FromServices] IWorkLoadService workLoadService, string id, [FromBody] WorkLoadInputDto input) => workLoadService.UpdateWorkLoadAsync(id, input);
    
    /// <summary>
    /// 删除部署
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteWorkLoadAsync([FromServices] IWorkLoadService workLoadService, string id) => workLoadService.DeleteDeploymentAsync(id);
    
    /// <summary>
    /// 分页获取部署列表
    /// </summary>
    /// <param name="workLoadQueryService"></param>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("{appId}/page/list")]
    public Task<PageBaseResult<WorkLoadOutputDto>> GetWorkLoadPageListAsync([FromServices] IWorkLoadQueryService workLoadQueryService, string appId, [FromQuery] WorkLoadQueryDto query) => workLoadQueryService.GetWorkLoadPageListAsync(appId, query);
    
    /// <summary>
    /// 查询部署明细
    /// </summary>
    /// <param name="workLoadQueryService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<WorkLoadOutputDto> GetWorkLoadForIdAsync([FromServices] IWorkLoadQueryService workLoadQueryService, string id) => workLoadQueryService.GetWorkLoadForIdAsync(id);
    
    /// <summary>
    /// 修改部署
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id}/publish")]
    public Task PublishWorkLoadAsync([FromServices] IWorkLoadService workLoadService, string id) => workLoadService.PublishWorkLoadAsync(id);

    /// <summary>
    /// 部署应用
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="id"></param>
    /// <param name="imageVersion"></param>
    /// <returns></returns>
    [HttpPut("{id}/{imageVersion}/deploy")]
    public Task DeployApplicationAsync([FromServices] IWorkLoadService workLoadService, string id, string imageVersion) => workLoadService.DeployApplicationAsync(id, imageVersion);

    /// <summary>
    /// 修改部署更新策略
    /// </summary>
    /// <param name="workLoadService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}/strategy")]
    public Task UpdateWorkLoadStrategyAsync([FromServices] IWorkLoadService workLoadService, string id,[FromBody] StrategyInputDto input) => workLoadService.UpdateWorkLoadStrategyAsync(id, input);
}
