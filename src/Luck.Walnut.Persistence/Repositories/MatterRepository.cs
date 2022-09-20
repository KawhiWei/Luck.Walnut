using Luck.EntityFrameworkCore.DbContexts;
using Luck.EntityFrameworkCore.Repositories;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Matters;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Matters;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Persistence.Repositories;

public class MatterRepository : EfCoreAggregateRootRepository<Matter, string>, IMatterRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public MatterRepository(ILuckDbContext dbContext, IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateMatterAsync(MatterInputDto input)
    {
        var matter = new Matter(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
            input.ProductPrincipal, input.MainProductManager, input.ProductAim, input.MatterType, input.PlanOnlineTime, input.ProductManagers);
        base.Add(matter);
        await _unitOfWork.CommitAsync();
    }

    public async Task<Matter?> GetMatterAsync(string id)
    {
        return await base.FindAsync(id);
    }

    public async Task UpdateMatterAsync(string id, MatterInputDto input)
    {
        var matter = await base.FindAsync(id);

        if (matter is null)
            return;

        var matters = new Matter(input.Name, input.Describe, input.ProjectId, input.Complexity, input.PriorityLevel,
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

    public async Task<List<Matter>> GetMatterListAsync(MatterQueryDto input) => await base.FindAll().ToListAsync();
}