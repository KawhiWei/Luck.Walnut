using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarApps;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarAppRepository : EfCoreAggregateRootRepository<ToyarApp, string>, IToyarAppRepository
{
    public ToyarAppRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarApp?> FindToyarAppByAppId(string appId,bool isInclude)
    {
        var queryable=FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarAppEnvironmentRelations)
                .Include(x => x.ToyarAppUserRelations);
        }
           
        return queryable.FirstOrDefaultAsync(x => x.AppId == appId);
    }
    
    public Task<ToyarApp?> FindToyarAppById(string id,bool isInclude)
    {
        var queryable=FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarAppEnvironmentRelations)
                .Include(x => x.ToyarAppUserRelations);
        }
           
        return queryable.FirstOrDefaultAsync(x => x.Id == id);
    }
}