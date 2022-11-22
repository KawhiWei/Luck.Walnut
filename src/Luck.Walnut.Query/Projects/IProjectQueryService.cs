using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Projects;

namespace Luck.Walnut.Query.Projects;

public interface IProjectQueryService:IScopedDependency
{

    Task<PageBaseResult<ProjectOutputDto>> GetProjectPageListAsync(ProjectQueryDto queryDto);

    /// <summary>
    /// 获取枚举
    /// </summary>
    /// <returns></returns>
    IEnumerable<KeyValuePair<string, string>> GetProjectEnumList();
}