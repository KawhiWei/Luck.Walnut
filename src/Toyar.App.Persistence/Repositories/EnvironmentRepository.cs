using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;

namespace Toyar.App.Persistence.Repositories;

public class EnvironmentRepository : EfCoreAggregateRootRepository<AppEnvironment, string>, IEnvironmentRepository
{
    public EnvironmentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<AppEnvironment?> FirstOrDefaultByEnvironmentNameAsync(string name)
    {
        return FindAll(x => x.Name == name).FirstOrDefaultAsync();
    }

    public Task<AppEnvironment?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id).FirstOrDefaultAsync();
    }
}