using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarBaseComponents;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarBaseComponentRepository : EfCoreAggregateRootRepository<ToyarBaseComponent, string>,
    IToyarBaseComponentRepository
{
    public ToyarBaseComponentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }
    
    public Task<ToyarBaseComponent?> FindToyarBaseComponentByIdAsync(string id)
        => FindAll(x => x.Id == id).FirstOrDefaultAsync();
}