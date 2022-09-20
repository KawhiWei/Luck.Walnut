using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Issues;

namespace Luck.Walnut.Query.Issues;

public class IssueQueryService : IIssueQueryService
{
    private readonly IIssueRepository _issueRepository;

    public IssueQueryService(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public async Task<IssueOutputDto?> GetIssueAsync(string id)
    {
        var matter = await _issueRepository.GetMatterAsync(id);
        if (matter is null)
            return null;

        return new IssueOutputDto()
        {
            Name = matter.Name,
            Describe = matter.Describe,
            ProjectId = matter.ProjectId,
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

    public async Task<PageBaseResult<IssueOutputDto>> GetIssueListAsync(IssueQueryDto input)
    {
        var totalCount = await _issueRepository.FindAll().CountAsync();
        var matters = await _issueRepository.GetMatterListAsync(input);
        var resultData = matters.Select(x => new IssueOutputDto()
        {
            Name = x.Name,
            Describe = x.Describe,
            ProjectId = x.ProjectId,
            Complexity = x.Complexity,
            PriorityLevel = x.PriorityLevel,
            ProductPrincipal = x.ProductPrincipal,
            MainProductManager = x.MainProductManager,
            ProductAim = x.ProductAim,
            MatterType = x.MatterType,
            PlanOnlineTime = x.PlanOnlineTime,
            ProductManagers = x.ProductManagers,
        }).ToArray();
        return new PageBaseResult<IssueOutputDto>(totalCount, resultData);
    }
}