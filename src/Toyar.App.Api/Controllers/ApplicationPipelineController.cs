using Toyar.App.AppService.Pipelines;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Query.Pipelines;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers;

[ApiController]
[Route("api/applicationpipelines")]
public class ApplicationPipelineController : BaseController
{
    /// <summary>
    /// 创建流水线
    /// </summary>
    /// <param name="pipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<string> CreatePipelineAsync([FromServices] IApplicationPipelineService pipelineService, [FromBody] ApplicationPipelineInputDto input)
        => pipelineService.CreatePipelineAsync(input);

    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdatePipelineAsync(string id, [FromServices] IApplicationPipelineService pipelineService, [FromBody] ApplicationPipelineInputDto input)
        => pipelineService.UpdateAsync(id, input);

    /// <summary>
    /// 修改流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}/pipeline/flow")]
    public Task UpdatePipelineFlowAsync(string id, [FromServices] IApplicationPipelineService pipelineService, [FromBody] ApplicationPipelineFlowUpdateInputDto input)
        => pipelineService.UpdatePipelineFlowAsync(id, input);

    /// <summary>
    /// 删除流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeletePipelineAsync(string id, [FromServices] IApplicationPipelineService pipelineService)
        => pipelineService.DeleteAsync(id);


    /// <summary>
    /// 根据AppId分页查询流水线列表
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{appId}/page/list")]
    public Task<PageBaseResult<ApplicationPipelineOutputDto>> GetPipelinePageListAsync(string appId, [FromQuery] PipelineQueryDto query, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetPipelinePageListAsync(appId, query);


    /// <summary>
    /// 根据id查询流水线详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<ApplicationPipelineOutputDto> GetPipelineDetailForIdAsync(string id, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetApplicationPipelineDetailForIdAsync(id);



    /// <summary>
    /// 执行一次job
    /// </summary>
    /// <param name="pipelineService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost("{id}/execute/job")]
    public Task ExecuteJobAsync([FromServices] IApplicationPipelineService pipelineService, string id)
        => pipelineService.ExecuteJobAsync(id);
    
    /// <summary>
    /// 发布流水线
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpPut("{id}/publish")]
    public Task PublishPipelineAsync(string id, [FromServices] IApplicationPipelineService pipelineService)
        => pipelineService.PublishAsync(id);


    /// <summary>
    /// Webhook同步JenkinsJob执行的状态
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pipelineService"></param>
    /// <returns></returns>
    [HttpPut("{id}/{jenkinsBuildNumber}/webhook/status")]
    public Task WebHookSyncJenkinsExecutedRecord(string id,uint jenkinsBuildNumber, [FromServices] IApplicationPipelineService pipelineService)
        => pipelineService.WebHookSyncJenkinsExecutedRecordAsync(id, jenkinsBuildNumber);

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
    /// <param name="pipelineId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{pipelineId}/pipelineId/page/list")]
    public Task<PageBaseResult<ApplicationPipelineHistoryOutputDto>> GetPipelineHistoryForPipeLineIdPageList(string pipelineId,[FromQuery] ApplicationPipelineHistoryQueryDto query, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetPipelineHistoryForPipeLineIdPageListAsync(pipelineId, query);
    
    /// <summary>
    /// 根据任务Id和Jenkins执行的BuildNumber获取执行日志
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="query"></param>
    /// <param name="applicationPipelineQueryService"></param>
    /// <returns></returns>
    [HttpGet("{appId}/appId/page/list")]
    public Task<PageBaseResult<ApplicationPipelineHistoryOutputDto>> GetPipelineHistoryForAppIdPageList(string appId,[FromQuery] ApplicationPipelineHistoryQueryDto query, [FromServices] IPipelineQueryService applicationPipelineQueryService)
        => applicationPipelineQueryService.GetPipelineHistoryForAppIdPageListAsync(appId, query);
}