using Luck.Walnut.Domain.AggregateRoots.Projects;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Domain.Repositories;

public interface IProjectRepository: IAggregateRootRepository<Project,string>,IScopedDependency
{

    /// <summary>
    /// 根据项目id获取项目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Project?> FindFirstOrDefaultByIdAsync(string id);
    
    /// <summary>
    /// 分页获取项目列表
    /// </summary>
    /// <param name="baseInputDto"></param>
    /// <returns></returns>
    Task<PageBaseResult<ProjectOutputDto>> GetProjectPageListAsync(PageBaseInputDto baseInputDto);

    /// <summary>
    /// 根据项目Id数据查询符合的项目
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    Task<IList<ProjectOutputDto>> GetProjectPageListAsync(IList<string> ids);

}