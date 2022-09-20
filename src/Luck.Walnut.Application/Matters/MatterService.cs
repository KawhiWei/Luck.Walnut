using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.Matters;

namespace Luck.Walnut.Application.Matters;

public class MatterService : IMatterService
{
    private readonly IMatterRepository _matterRepository;
    public MatterService(IMatterRepository matterRepository)
    {
        _matterRepository = matterRepository;
    }

    public async Task CreateMatterAsync(MatterInputDto input)
    {
        var matter = new Matter(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
            input.ProductPrincipal, input.MainProductManager, input.ProductAim, input.MatterType, input.PlanOnlineTime, input.ProductManagers);
        
        await _matterRepository.CreateMatterAsync(input);
    }

    public Task UpdateMatterAsync(string id, MatterInputDto input) => _matterRepository.UpdateMatterAsync(id, input);

    public Task DeleteMatterAsync(string id) => _matterRepository.DeleteMatterAsync(id);
    
}