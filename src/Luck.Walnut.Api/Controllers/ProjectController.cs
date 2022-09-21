using Luck.Walnut.Application.Projects;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;
using Luck.Walnut.Query.Projects;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;


[ApiController]
[Route("api/projects")]
public class ProjectController : BaseController
{
    /// <summary>
    /// 创建项目
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="input"></param>
    [HttpPost]
    public Task CreateProjectAsync([FromServices] IProjectService matterService, [FromBody] ProjectInputDto input) =>
        matterService.CreateProjectAsync(input);


    /// <summary>
    /// 修改项目信息
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="id"></param>
    /// <param name="input"></param>
    [HttpPut("{id}")]
    public Task CreateProjectAsync([FromServices] IProjectService matterService, string id, [FromBody] ProjectInputDto input) =>
        matterService.UpdateProjectAsync(id, input);


    /// <summary>
    /// 删除项目
    /// </summary>
    /// <param name="matterService"></param>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public Task DeleteProjectAsync([FromServices] IProjectService matterService, string id) =>
        matterService.DeleteProjectAsync(id);


    /// <summary>
    /// 获取项目列表
    /// </summary>
    /// <param name="projectQueryService"></param>
    /// <param name="input"></param>
    [HttpGet("pagelist")]
    public Task<PageBaseResult<ProjectOutputDto>> GetProjectPageListAsync([FromServices] IProjectQueryService projectQueryService, [FromQuery] ProjectQueryDto input) =>
        projectQueryService.GetProjectPageListAsync(input);
    
    
    /// <summary>
    /// 获取项目列表
    /// </summary>
    /// <param name="projectQueryService"></param>
    [HttpGet("enumlist")]
    public IEnumerable<KeyValuePair<string, string>> GetProjectEnumList([FromServices] IProjectQueryService projectQueryService) =>
        projectQueryService.GetProjectEnumList();
    
}