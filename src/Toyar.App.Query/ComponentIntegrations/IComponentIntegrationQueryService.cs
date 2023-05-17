using Toyar.App.Dto;
using Toyar.App.Dto.ComponentIntegrations;

namespace Toyar.App.Query.ComponentIntegrations;

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
    
}