using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Query.ComponentIntegrations;

public interface IComponentIntegrationQueryService : IScopedDependency
{
    /// <summary>
    /// 分页查询接口
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<PageBaseResult<ComponentIntegrationOutputDto>> GetComponentIntegrationPageListAsync(ComponentIntegrationQueryDto query);
    
    /// <summary>
    /// 明细查询
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ComponentIntegrationOutputDto> GetDetailForIdAsync(string id);

    /// <summary>
    /// 获取枚举列表
    /// </summary>
    /// <returns></returns>
    Task<object> GetComponentIntegrationEnumListAsync();
}