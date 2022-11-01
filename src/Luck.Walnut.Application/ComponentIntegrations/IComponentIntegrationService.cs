using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Application.ComponentIntegrations;

public interface IComponentIntegrationService : IScopedDependency
{
    /// <summary>
    /// 添加组件以及组件链接等
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task AddComponentIntegrationAsync(ComponentIntegrationInputDto input);

    /// <summary>
    /// 修改组件集成配置
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateComponentIntegrationAsync(string id, ComponentIntegrationInputDto input);

    /// <summary>
    /// 删除组件集成配置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteComponentIntegrationAsync(string id);
}