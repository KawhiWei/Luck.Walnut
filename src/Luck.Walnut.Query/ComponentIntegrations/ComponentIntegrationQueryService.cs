using Luck.Framework.Exceptions;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.ComponentIntegrations;
using Luck.Walnut.Infrastructure;

namespace Luck.Walnut.Query.ComponentIntegrations;

public class ComponentIntegrationQueryService : IComponentIntegrationQueryService
{
    private readonly IComponentIntegrationRepository _componentIntegrationRepository;

    public ComponentIntegrationQueryService(IComponentIntegrationRepository componentIntegrationRepository)
    {
        _componentIntegrationRepository = componentIntegrationRepository;
    }

    public async Task<PageBaseResult<ComponentIntegrationOutputDto>> GetComponentIntegrationPageListAsync(ComponentIntegrationQueryDto query)
    {
        var result = await _componentIntegrationRepository.GetComponentIntegrationPageListAsync(query);
        return new PageBaseResult<ComponentIntegrationOutputDto>(result.TotalCount, result.Data);
    }

    public async Task<ComponentIntegrationOutputDto> GetDetailForIdAsync(string id)
    {
        var componentIntegration = await GetComponentIntegrationAsync(id);
        return new ComponentIntegrationOutputDto
        {
            Id = componentIntegration.Id,
            Name = componentIntegration.Name,
            ComponentType = componentIntegration.ComponentType,
            UserName = componentIntegration.Credential.UserName,
            PassWord = componentIntegration.Credential.PassWord,
            Token = componentIntegration.Credential.Token,
            ComponentLinkUrl = componentIntegration.Credential.ComponentLinkUrl,
            ComponentCategory = componentIntegration.ComponentCategory,
        };
    }


    private async Task<ComponentIntegration> GetComponentIntegrationAsync(string id)
    {
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(id);
        if (componentIntegration is null)
            throw new BusinessException($"组件集成不存在");
        return componentIntegration;
    }
}