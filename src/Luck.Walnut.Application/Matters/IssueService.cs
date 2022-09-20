using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.Issues;

namespace Luck.Walnut.Application.Matters;

public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;
    public IssueService(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task CreateIssueAsync(IssueInputDto input)
    {
        var matter = new Issue(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
            input.ProductPrincipal, input.MainProductManager, input.ProductAim, input.MatterType, input.PlanOnlineTime, input.ProductManagers);
        
        await _issueRepository.CreateMatterAsync(input);
    }

    public Task UpdateIssueAsync(string id, IssueInputDto input) => _issueRepository.UpdateMatterAsync(id, input);

    public Task DeleteIssueAsync(string id) => _issueRepository.DeleteMatterAsync(id);
    
}