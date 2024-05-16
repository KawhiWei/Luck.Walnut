using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.AggregateRoots.ToyarRoles;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarRoleRepository : EfCoreAggregateRootRepository<ToyarRole, string>, IToyarRoleRepository
{
    public ToyarRoleRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarRole?> FindToyarRoleByEnglishName(string englishName) => FindAll()
        .Include(x => x.ToyarRoleUserRelations)
        .FirstOrDefaultAsync(x => x.EnglishName == englishName);
}