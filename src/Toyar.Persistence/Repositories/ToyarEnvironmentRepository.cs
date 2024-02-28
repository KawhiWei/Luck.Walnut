using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.Environments;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarEnvironmentRepository : EfCoreAggregateRootRepository<ToyarEnvironment, string>,
    IToyarEnvironmentRepository
{
    public ToyarEnvironmentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarEnvironment?> FindToyarEnvironmentByName(string name) =>
        FindAll(x => x.Name == name).FirstOrDefaultAsync();
}