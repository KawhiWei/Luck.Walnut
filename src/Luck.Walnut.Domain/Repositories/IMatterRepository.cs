using Luck.Framework.Infrastructure.DependencyInjectionModule;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Matters;

namespace Luck.Walnut.Domain.Repositories;

public interface IMatterRepository: IAggregateRootRepository<Matter,string>,IScopedDependency
{
    
    
    Task CreateMatterAsync(MatterInputDto input);


    Task<Matter?> GetMatterAsync(string id);
    
    Task UpdateMatterAsync(string id,MatterInputDto input);
    
    Task DeleteMatterAsync(string id);



    Task<List<Matter>> GetMatterListAsync(MatterQueryDto input);
}