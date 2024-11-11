using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.Repositories;

namespace Toyar.Persistence.Repositories;

public class ToyarApplicationRepository : EfCoreAggregateRootRepository<ToyarApplication, string>,
    IToyarApplicationRepository
{
    public ToyarApplicationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public Task<ToyarApplication?> FindToyarAppByAppId(string appId, bool isInclude)
    {
        var queryable = FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarApplicationEnvironmentRelations)
                .Include(x => x.ToyarApplicationPermissionRelations)
                .Include(x => x.ToyarApplicationDeploymentConfigurations);
        }

        return queryable.FirstOrDefaultAsync(x => x.AppId == appId);
    }

    public Task<ToyarApplication?> FindToyarById(string id, bool isInclude)
    {
        var queryable = FindAll();
        if (isInclude)
        {
            queryable = queryable
                .Include(x => x.ToyarApplicationEnvironmentRelations)
                .Include(x => x.ToyarApplicationPermissionRelations)
                .Include(x => x.ToyarApplicationDeploymentConfigurations);
        }

        return queryable.FirstOrDefaultAsync(x => x.Id == id);
    }
}