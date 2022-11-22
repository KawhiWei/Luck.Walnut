using Luck.Walnut.Domain.AggregateRoots.Issues;
using Luck.Walnut.Dto.Issues;

namespace Luck.Walnut.Domain.Repositories;

public interface IIssueRepository: IAggregateRootRepository<Issue,string>,IScopedDependency
{
    
    
    Task CreateMatterAsync(IssueInputDto input);


    Task<Issue?> GetMatterAsync(string id);
    
    Task UpdateMatterAsync(string id,IssueInputDto input);
    
    Task DeleteMatterAsync(string id);



    Task<List<Issue>> GetMatterListAsync(IssueQueryDto input);
}