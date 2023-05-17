using Toyar.App.Domain.AggregateRoots.ComponentIntegrations;
using Toyar.App.Dto;
using Toyar.App.Dto.ComponentIntegrations;

namespace Toyar.App.Domain.Repositories;

public interface IComponentIntegrationRepository : IAggregateRootRepository<ComponentIntegration, string>, IScopedDependency
{
    /// <summary>
    /// 获取一个集成组件
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ComponentIntegration> FindFirstByIdAsync(string id);

    /// <summary>
    /// 获取分页数据
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    Task<(ComponentIntegrationOutputDto[] Data,int TotalCount)> GetComponentIntegrationPageListAsync(ComponentIntegrationQueryDto query);
}