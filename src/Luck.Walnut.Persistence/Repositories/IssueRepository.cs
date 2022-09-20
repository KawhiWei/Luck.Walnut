using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.Issues;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Persistence.Repositories;

public class IssueRepository : EfCoreAggregateRootRepository<Issue, string>, IIssueRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public IssueRepository(ILuckDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateMatterAsync(IssueInputDto input)
    {
        var matter = new Issue(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
            input.ProductPrincipal, input.MainProductManager, input.ProductAim, input.MatterType, input.PlanOnlineTime, input.ProductManagers);
        base.Add(matter);
        await _unitOfWork.CommitAsync();
    }

    public async Task<Issue?> GetMatterAsync(string id)
    {
        return await base.FindAsync(id);
    }

    public async Task UpdateMatterAsync(string id, IssueInputDto input)
    {
        var matter = await base.FindAsync(id);

        if (matter is null)
            return;

        var matters = new Issue(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
            input.ProductPrincipal, input.MainProductManager, input.ProductAim, input.MatterType, input.PlanOnlineTime, input.ProductManagers);

        base.Update(matter);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteMatterAsync(string id)
    {
        var matter = await base.FindAsync(id);

        if (matter is null)
            return;

        base.Remove(matter);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Issue>> GetMatterListAsync(IssueQueryDto input) => await base.FindAll().ToListAsync();
}