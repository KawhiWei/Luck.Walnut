using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarBaseComponents;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarBaseComponentRepository : EfCoreAggregateRootRepository<ToyarBaseComponent, string>,
    IToyarBaseComponentRepository
{
    public ToyarBaseComponentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
    public Task<ToyarBaseComponent?> FindToyarBaseComponentByIdAsync(string id)
        => FindAll(x => x.Id == id).FirstOrDefaultAsync();
}