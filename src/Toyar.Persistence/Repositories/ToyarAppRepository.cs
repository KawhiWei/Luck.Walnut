using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarApps;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarAppRepository : EfCoreAggregateRootRepository<ToyarApp, string>, IToyarAppRepository
{
    public ToyarAppRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarApp?> FindToyarAppByAppId(string appId) => FindAll()
        .Include(x => x.ToyarAppEnvironmentRelations)
        .Include(x => x.ToyarAppUserRelations)
        .FirstOrDefaultAsync(x => x.AppId == appId);
}