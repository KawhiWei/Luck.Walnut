using Luck.Walnut.Application.ComponentIntegrations;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ComponentIntegrations;
using Luck.Walnut.Query.ComponentIntegrations;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

[ApiController]
[Route("api/component/integrations")]
public class ComponentIntegrationController : BaseController
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("page")]
    public Task<PageBaseResult<ComponentIntegrationOutputDto>> GetComponentIntegrationPageListAsync([FromServices] IComponentIntegrationQueryService componentIntegrationQueryService, [FromQuery] ComponentIntegrationQueryDto query)
        => componentIntegrationQueryService.GetComponentIntegrationPageListAsync(query);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<ComponentIntegrationOutputDto> GetDetailForIdAsync([FromServices] IComponentIntegrationQueryService componentIntegrationQueryService,string id)
        => componentIntegrationQueryService.GetDetailForIdAsync(id);
    
    /// <summary>
    /// 添加组件配置
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public Task AddComponentIntegrationAsync([FromServices] IComponentIntegrationService componentIntegrationService, [FromBody] ComponentIntegrationInputDto input)
        => componentIntegrationService.AddComponentIntegrationAsync(input);


    /// <summary>
    /// 修改组件配置
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateComponentIntegrationAsync([FromServices] IComponentIntegrationService componentIntegrationService, string id, [FromBody] ComponentIntegrationInputDto input)
        => componentIntegrationService.UpdateComponentIntegrationAsync(id, input);


    /// <summary>
    /// 删除组件配置
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteComponentIntegrationAsync([FromServices] IComponentIntegrationService componentIntegrationService, string id)
        => componentIntegrationService.DeleteComponentIntegrationAsync(id);
}