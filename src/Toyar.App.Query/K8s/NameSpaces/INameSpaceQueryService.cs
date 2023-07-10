using Toyar.App.Dto;
using Toyar.App.Dto.K8s.NameSpaces;

namespace Toyar.App.Query.K8s.NameSpaces;

public interface INameSpaceQueryService : IScopedDependency
{
    /// <summary>
    /// 分页获取命名空间列表
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<PageBaseResult<NameSpaceOutputDto>> GetNameSpacePageListAsync(NameSpaceQueryDto query);

    /// <summary>
    /// 根据Id查询一个明明空间详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<NameSpaceOutputDto?> GetNameSpaceDetailByIdAsync(string id);


    /// <summary>
    /// 获取NameSpace列表
    /// </summary>
    /// <returns></returns>
    Task<List<NameSpaceOutputDto>> GetNameSpaceListAsync();
}