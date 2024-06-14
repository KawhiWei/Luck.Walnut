using Luck.EntityFrameworkCore.DbContexts;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarApplicationRepository : EfCoreAggregateRootRepository<ToyarApplication, string>, IToyarApplicationRepository
{
    public ToyarApplicationRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarApplication?> FindToyarAppByAppId(string appId,bool isInclude)
    {
        var queryable=FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarAppEnvironmentRelations)
                .Include(x => x.ToyarAppPermissionRelations);
        }
           
        return queryable.FirstOrDefaultAsync(x => x.AppId == appId);
    }
    
    public Task<ToyarApplication?> FindToyarAppById(string id,bool isInclude)
    {
        var queryable=FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarAppEnvironmentRelations)
                .Include(x => x.ToyarAppPermissionRelations);
        }
           
        return queryable.FirstOrDefaultAsync(x => x.Id == id);
    }
}