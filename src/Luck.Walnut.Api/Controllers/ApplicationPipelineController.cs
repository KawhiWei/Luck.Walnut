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
}