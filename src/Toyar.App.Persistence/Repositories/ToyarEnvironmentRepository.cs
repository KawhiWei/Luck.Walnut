using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Persistence.Repositories;

public class ToyarEnvironmentRepository : EfCoreAggregateRootRepository<ToyarEnvironment, string>, IToyarEnvironmentRepository
{
    public ToyarEnvironmentRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public Task<ToyarEnvironment?> FirstOrDefaultByNameAsync(string name)
    {
        return FindAll(x => x.Name == name).FirstOrDefaultAsync();
    }

    public Task<ToyarEnvironment?> FirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<(ToyarEnvironment[] Data, int TotalCount)> GetPageListAsync(ToyarEnvironmentQueryDto query)
    {
        var queryable = FindAll()
            .WhereIf(x => x.Name.Contains(query.EnvironmentName), !query.EnvironmentName.IsNullOrWhiteSpace())
            .OrderByDescending(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list.ToArray(), totalCount);
    }
}

