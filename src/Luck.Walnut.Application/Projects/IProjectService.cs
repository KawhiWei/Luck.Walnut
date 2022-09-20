using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Application.Projects;

public interface IProjectService:IScopedDependency
{
    
    /// <summary>
    /// 创建一个项目
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateProjectAsync(ProjectInputDto input);

    /// <summary>
    /// 修改项目信息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateProjectAsync(string id, ProjectInputDto input);


    Task DeleteProjectAsync(string id);
}