using Toyar.App.AppService.Pipelines;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Query.Pipelines;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers;

[ApiController]
[Route("api/applicationpipelines")]
public class PipelineController : BaseController
{
    /// <summary>
    /// 创建流水线
    /// </summary>
    /// <param name="pipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task CreateApplicationPipelineAsync([FromServices] IPipelineService pipelineService, [FromBody] PipelineInputDto input)
        => pipelineService.CreateAsync(input);

    /// <summary>
    /// 执行一次job
    /// </summary>
    /// <param name="pipelineService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}/execute/job")]
    public Task ExecuteJobAsync([FromServices] IPipelineService pipelineService, string id)
        => pipelineService.ExecuteJobAsync(id);


    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdatePipelineAsync(string id, [FromServices] IPipelineService pipelineService, [FromBody] PipelineInputDto input)
        => pipelineService.UpdateAsync(id, input);


    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpPut("{id}/publish")]
    public Task PublishPipelineAsync(string id, [FromServices] IPipelineService pipelineService)
        => pipelineService.PublishAsync(id);


    /// <summary>
    /// Webhook同步JenkinsJob执行的状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpPut("{id}/{jenkinsBuildNumber}/webhook/sync/jenkins/status")]
    public Task WebHookSyncJenkinsExecutedRecord(string id,uint jenkinsBuildNumber, [FromServices] IPipelineService pipelineService)
        => pipelineService.WebHookSyncJenkinsExecutedRecordAsync(id, jenkinsBuildNumber);

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeletePipelineAsync(string id, [FromServices] IPipelineService pipelineService)
        => pipelineService.DeleteAsync(id);

    /// <summary>
    /// 根据AppId分页查询流水线列表
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// 
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{appId}/page/list")]
    public Task<PageBaseResult<PipelineOutputDto>> GetPipelinePageListAsync(string appId, [FromQuery] PipelineQueryDto query, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetPipelinePageListAsync(appId, query);

    /// <summary>
    /// 根据id查询流水线详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<PipelineOutputDto> GetPipelineDetailForIdAsync(string id, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetApplicationPipelineDetailForIdAsync(id);


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
    public Task<string> GetJenkinsJobBuildDetailAsync(string appId,string id, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetJenkinsJobBuildLogsAsync(appId, id);
    
    
    /// <summary>
    /// 根据任务Id和Jenkins执行的BuildNumber获取执行日志
    /// </summary>
    /// <param name="applicationPipelineId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{applicationPipelineId}/executed/record/page/list")]
    public Task<PageBaseResult<ApplicationPipelineExecutedRecordOutputDto>> GetJenkinsJobBuildDetailAsync(string applicationPipelineId,[FromQuery] ApplicationPipelineExecutedQueryDto query, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetPipelineExecutedRecordPageListAsync(applicationPipelineId, query);
}