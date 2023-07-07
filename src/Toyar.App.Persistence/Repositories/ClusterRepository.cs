using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Applications;
using Toyar.App.Dto.K8s.Clusters;

namespace Toyar.App.Persistence.Repositories;

public class ClusterRepository : EfCoreAggregateRootRepository<Cluster, string>, IClusterRepository
{
    public ClusterRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<(Cluster[] Data, int TotalCount)> GetClusterPageListAsync(ClusterQueryDto query)
    {
        var queryable = FindAll()
        .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
        .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (queryable.ToArray(), totalCount);


    }

    public Task<Cluster?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id).FirstOrDefaultAsync();
    }
}