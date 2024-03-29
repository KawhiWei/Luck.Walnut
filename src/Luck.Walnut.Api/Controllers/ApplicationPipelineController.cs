using Luck.Walnut.Adapter.JenkinsAdapter;
using Luck.Walnut.Application.ApplicationPipelines;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ApplicationPipelines;
using Luck.Walnut.Query.ApplicationPipelines;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

[ApiController]
[Route("api/applicationpipelines")]
public class ApplicationPipelineController : BaseController
{
    /// <summary>
    /// 创建流水线
    /// </summary>
    /// <param name="applicationPipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task CreateApplicationPipelineAsync([FromServices] IApplicationPipelineService applicationPipelineService, [FromBody] ApplicationPipelineInputDto input)
        => applicationPipelineService.CreateAsync(input);

    /// <summary>
    /// 执行一次job
    /// </summary>
    /// <param name="applicationPipelineService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}/execute/job")]
    public Task ExecuteJobAsync([FromServices] IApplicationPipelineService applicationPipelineService, string id)
        => applicationPipelineService.ExecuteJobAsync(id);


    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateApplicationPipelineAsync(string id, [FromServices] IApplicationPipelineService applicationPipelineService, [FromBody] ApplicationPipelineInputDto input)
        => applicationPipelineService.UpdateAsync(id, input);


    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineService"></param>
    /// <returns></returns>
    [HttpPut("{id}/publish")]
    public Task PublishApplicationPipelineAsync(string id, [FromServices] IApplicationPipelineService applicationPipelineService)
        => applicationPipelineService.PublishAsync(id);

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineService"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteApplicationPipelineAsync(string id, [FromServices] IApplicationPipelineService applicationPipelineService)
        => applicationPipelineService.DeleteAsync(id);

    /// <summary>
    /// 根据AppId分页查询流水线列表
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{appId}/page/list")]
    public Task<PageBaseResult<ApplicationPipelineOutputDto>> GetApplicationPageListAsync(string appId, [FromQuery] ApplicationPipelineQueryDto query, [FromServices] IApplicationPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetApplicationPageListAsync(appId, query);

    /// <summary>
    /// 根据id查询流水线详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<ApplicationPipelineOutputDto> GetApplicationDetailForIdAsync(string id, [FromServices] IApplicationPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetApplicationDetailForIdAsync(id);


    // /// <summary>
    // /// 根据id查询流水线详情
    // /// </summary>
    // /// <param name="id"></param>
    // /// <param name="applicationPipelineQueryService"></param>
    // /// <returns></returns>
    // [HttpGet("{id}/test")]
    // public Task<object> GetJenkinsJobBuildDetailAsync(string id, [FromServices] IApplicationPipelineQueryService applicationPipelineQueryService)
    //     => applicationPipelineQueryService.GetJenkinsJobBuildDetailAsync(id);

    /// <summary>
    /// 根据任务Id和Jenkins执行的BuildNumber获取执行日志
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="id"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{appId}/{id}/build/log")]
    public Task<string> GetJenkinsJobBuildDetailAsync(string appId,string id, [FromServices] IApplicationPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetJenkinsJobBuildLogsAsync(appId, id);
    
    
    /// <summary>
    /// 根据任务Id和Jenkins执行的BuildNumber获取执行日志
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{applicationPipelineId}/executed/record/page/list")]
    public Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetJenkinsJobBuildDetailAsync(string applicationPipelineId,[FromQuery] ApplicationPipelineExecutedQueryDto query, [FromServices] IApplicationPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetApplicationPipelineExecutedRecordPageListAsync(applicationPipelineId, query);
}