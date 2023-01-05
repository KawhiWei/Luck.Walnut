using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Persistence.Repositories;

public class ComponentIntegrationRepository : EfCoreAggregateRootRepository<ComponentIntegration, string>, IComponentIntegrationRepository
{
    private readonly IDictionary<string, ComponentIntegration> _componentIntegrations;

    public ComponentIntegrationRepository(ILuckDbContext dbContext) : base(dbContext)
    {
        _componentIntegrations = new Dictionary<string, ComponentIntegration>();
    }


    public async Task<ComponentIntegration> FindFirstByIdAsync(string id)
    {
        if (_componentIntegrations.ContainsKey(id))
        {
            return _componentIntegrations[id];
        }

        var componentIntegration = await FindAll().FirstOrDefaultAsync(x => x.Id == id);
        if (componentIntegration is null)
        {
            throw new BusinessException($"组件集成流水线不存在");
        }
        _componentIntegrations.Add(id, componentIntegration);
        return componentIntegration;
    }

    public async Task<(ComponentIntegrationOutputDto[] Data, int TotalCount)> GetComponentIntegrationPageListAsync(ComponentIntegrationQueryDto query)
    {
        var queryable = FindAll().Select(x => new ComponentIntegrationOutputDto
            {
                Id = x.Id,
                Name = x.Name,
                ComponentType = x.ComponentType,
            })
            .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
            .WhereIf(x => x.ComponentType == query.ComponentLinkType, query.ComponentLinkType.HasValue)
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }
}