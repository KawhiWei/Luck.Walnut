using Luck.Walnut.Application.Matters;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Matters;
using Luck.Walnut.Query.Matters;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

/// <summary>
/// 需求事项
/// </summary>
[ApiController]
[Route("api/matters")]
public class MatterController : BaseController
{
    /// <summary>
    /// 获取一个事项
    /// </summary>
    /// <param name="matterQueryService"></param>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public Task<MatterOutputDto?> GetMatterAsync([FromServices] IMatterQueryService matterQueryService , string id) =>
        matterQueryService.GetMatterAsync(id);
    
    
    /// <summary>
    /// 获取一个事项
    /// </summary>
    /// <param name="matterQueryService"></param>
    /// <param name="input"></param>
    [HttpGet("pagelist")]
    public Task<PageBaseResult<MatterOutputDto>> GetMatterListAsync([FromServices] IMatterQueryService matterQueryService ,[FromQuery] MatterQueryDto input) =>
        matterQueryService.GetMatterListAsync(input);
    
    /// <summary>
    /// 创建事项
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="input"></param>
    [HttpPost]
    public Task CreateMatterAsync([FromServices] IMatterService matterService, [FromBody] MatterInputDto input) =>
        matterService.CreateMatterAsync(input);
    
    /// <summary>
    /// 修改事项
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    [HttpPut("{id}")]
    public Task UpdateMatterAsync([FromServices] IMatterService matterService, string id, [FromBody] MatterInputDto input) =>
        matterService.CreateMatterAsync(input);
    
    /// <summary>
    /// 修改事项
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public Task DeleteMatterAsync([FromServices] IMatterService matterService, string id) =>
        matterService.DeleteMatterAsync(id);
}