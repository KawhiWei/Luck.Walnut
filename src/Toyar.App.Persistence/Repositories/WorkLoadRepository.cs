using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.WorkLoads;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.WorkLoads;

namespace Toyar.App.Persistence.Repositories;

public class WorkLoadRepository : EfCoreAggregateRootRepository<WorkLoad, string>, IWorkLoadRepository
{
    public WorkLoadRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<WorkLoad?> FirstOrDefaultByNameAsync(string name)
    {
        return FindAll(x => x.Name == name).FirstOrDefaultAsync();
    }

    public Task<WorkLoad?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id)
            .Include(x => x.Containers)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    public async Task<(WorkLoad[] Data, int TotalCount)> GetDeploymentPageListAsync(string appId, WorkLoadQueryDto query)
    {
        var queryable = FindAll(x => x.AppId == appId)
            .WhereIf(x => x.Name.Contains(query.EnvironmentName), !query.EnvironmentName.IsNullOrWhiteSpace())
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list.ToArray(), totalCount);
    }
}

