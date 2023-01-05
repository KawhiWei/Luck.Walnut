using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Application.ComponentIntegrations;

public class ComponentIntegrationService : IComponentIntegrationService
{
    private readonly IComponentIntegrationRepository _componentIntegrationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ComponentIntegrationService(IComponentIntegrationRepository componentIntegrationRepository, IUnitOfWork unitOfWork)
    {
        _componentIntegrationRepository = componentIntegrationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddComponentIntegrationAsync(ComponentIntegrationInputDto input)
    {
        var credential = new Credential(input.ComponentLinkUrl, input.UserName, input.PassWord, input.Token);
        var componentIntegration = new ComponentIntegration(input.Name, input.ComponentType, credential, input.ComponentCategory);
        _componentIntegrationRepository.Add(componentIntegration);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateComponentIntegrationAsync(string id, ComponentIntegrationInputDto input)
    {
        var componentIntegration = await GetComponentIntegrationAsync(id);
        componentIntegration.SetComponentLinkType(input.ComponentType)
            .SetComponentCategory(input.ComponentCategory)
            .SetCredential(input.ComponentLinkUrl, input.UserName, input.PassWord, input.Token);
        _componentIntegrationRepository.Update(componentIntegration);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="BusinessException"></exception>
    public async Task DeleteComponentIntegrationAsync(string id)
    {
        var componentIntegration = await GetComponentIntegrationAsync(id);
        _componentIntegrationRepository.Remove(componentIntegration);
        await _unitOfWork.CommitAsync();
    }

    private async Task<ComponentIntegration> GetComponentIntegrationAsync(string id)
    {
        var componentIntegration = await _componentIntegrationRepository.FindFirstByIdAsync(id);
        if (componentIntegration is null)
            throw new BusinessException($"组件集成不存在");
        return componentIntegration;
    }
}