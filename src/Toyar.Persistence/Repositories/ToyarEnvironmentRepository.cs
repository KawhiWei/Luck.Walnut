using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarEnvironmentRepository : EfCoreAggregateRootRepository<ToyarEnvironment, string>,
    IToyarEnvironmentRepository
{
    public ToyarEnvironmentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarEnvironment?> FindToyarEnvironmentByEnglishName(string englishName) => FindAll()
        .Include(x => x.ToyarEnvironmentUserRelations)
        .FirstOrDefaultAsync(x => x.EnglishName == englishName);
    
    public Task<ToyarEnvironment?> FindToyarEnvironmentDetailByIdAsync(string id) => FindAll()
        .Include(x => x.ToyarEnvironmentUserRelations)
        .FirstOrDefaultAsync(x => x.Id == id);
}