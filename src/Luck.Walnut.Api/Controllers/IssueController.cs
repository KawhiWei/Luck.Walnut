using Luck.Walnut.Application.Issues;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Issues;
using Luck.Walnut.Query.Issues;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

/// <summary>
/// 需求事项
/// </summary>
[ApiController]
[Route("api/issues")]
public class IssueController : BaseController
{
    /// <summary>
    /// 获取一个事项
    /// </summary>
    /// <param name="issueQueryService"></param>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public Task<IssueOutputDto?> GetIssueAsync([FromServices] IIssueQueryService issueQueryService , string id) =>
        issueQueryService.GetIssueAsync(id);
    
    
    /// <summary>
    /// 获取一个事项
    /// </summary>
    /// <param name="issueQueryService"></param>
    /// <param name="input"></param>
    [HttpGet("pagelist")]
    public Task<PageBaseResult<IssueOutputDto>> GetIssuePageListAsync([FromServices] IIssueQueryService issueQueryService ,[FromQuery] IssueQueryDto input) =>
        issueQueryService.GetIssueListAsync(input);
    
    /// <summary>
    /// 创建事项
    /// </summary>
    /// <param name="issueService"></param>
    /// <param name="input"></param>
    [HttpPost]
    public Task CreateMatterAsync([FromServices] IIssueService issueService, [FromBody] IssueInputDto input) =>
        issueService.CreateIssueAsync(input);
    
    /// <summary>
    /// 修改事项
    /// </summary>
    /// <param name="issueService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    [HttpPut("{id}")]
    public Task UpdateMatterAsync([FromServices] IIssueService issueService, string id, [FromBody] IssueInputDto input) =>
        issueService.UpdateIssueAsync(id,input);
    
    /// <summary>
    /// 修改事项
    /// </summary>
    /// <param name="issueService"></param>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public Task DeleteMatterAsync([FromServices] IIssueService issueService, string id) =>
        issueService.DeleteIssueAsync(id);
}