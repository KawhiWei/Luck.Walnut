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
        await _matterRepository.CreateMatterAsync(input);
    }

    public Task UpdateMatterAsync(string id, MatterInputDto input) => _matterRepository.UpdateMatterAsync(id, input);

    public Task DeleteMatterAsync(string id) => _matterRepository.DeleteMatterAsync(id);
    
    public async Task<MatterOutputDto?> GetMatterAsync(string id)
    { 
        var matter= await _matterRepository.GetMatterAsync(id);
        if (matter is null)
            return null;
        
        return new MatterOutputDto()
        {
            Name = matter.Name,
            Describe = matter.Describe,
            BusinessLine = matter.BusinessLine,
            Complexity = matter.Complexity,
            PriorityLevel = matter.PriorityLevel,
            ProductPrincipal = matter.ProductPrincipal,
            MainProductManager = matter.MainProductManager,
            ProductAim = matter.ProductAim,
            MatterType = matter.MatterType,
            PlanOnlineTime = matter.PlanOnlineTime,
            ProductManagers = matter.ProductManagers,
        };
        
    } 
}