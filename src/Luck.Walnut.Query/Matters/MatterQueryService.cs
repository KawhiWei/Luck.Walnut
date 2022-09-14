using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Matters;

namespace Luck.Walnut.Query.Matters;

public class MatterQueryService : IMatterQueryService
{
    private readonly IMatterRepository _matterRepository;

    public MatterQueryService(IMatterRepository matterRepository)
    {
        _matterRepository = matterRepository;
    }
    
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

    public async Task<PageBaseResult<MatterOutputDto>> GetMatterListAsync(MatterQueryDto input)
    {
        
        
        var totalCount= await _matterRepository.FindAll().CountAsync();
        var resultData=await  _matterRepository.GetMatterListAsync(input);
        return new PageBaseResult<MatterOutputDto>(totalCount, resultData.ToArray());
    }

}