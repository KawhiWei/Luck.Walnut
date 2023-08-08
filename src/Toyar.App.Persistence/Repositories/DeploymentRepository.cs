using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Deployments;

namespace Toyar.App.Persistence.Repositories;

public class DeploymentRepository : EfCoreAggregateRootRepository<Deployment, string>, IDeploymentRepository
{
    public DeploymentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Deployment?> FirstOrDefaultByNameAsync(string name)
    {
        return FindAll(x => x.Name == name).FirstOrDefaultAsync();
    }

    public Task<Deployment?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id)
            .Include(x => x.Containers)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<(Deployment[] Data, int TotalCount)> GetDeploymentPageListAsync(string appId, DeploymentQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .WhereIf(x => x.Name.Contains(query.EnvironmentName), !query.EnvironmentName.IsNullOrWhiteSpace())
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list.ToArray(), totalCount);
    }
}

