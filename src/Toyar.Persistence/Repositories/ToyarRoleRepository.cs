using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.AggregateRoots.ToyarRoles;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarRoleRepository : EfCoreAggregateRootRepository<ToyarRole, string>, IToyarRoleRepository
{
    public ToyarRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public Task<ToyarRole?> FindToyarRoleByEnglishNameAsync(string englishName) => FindAll()
        .FirstOrDefaultAsync(x => x.EnglishName == englishName);
}