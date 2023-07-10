using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.K8s.NameSpaces;

namespace Toyar.App.Persistence.Repositories;

public class NameSpaceRepository : EfCoreAggregateRootRepository<NameSpace, string>, INameSpaceRepository
{
    public NameSpaceRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// 分页查询命名空间列表
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<(NameSpace[] Data, int TotalCount)> GetNameSpacePageListAsync(NameSpaceQueryDto query)
    {
        var queryable = this.FindAll();

        var totalCount = await queryable.CountAsync();
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();

        return (list, totalCount);
    }

    public async Task<NameSpace?> FindNameSpaceByNameAndClusterIdAsync(string name, string clusterId)
    {
        return await this.FindAll().FirstOrDefaultAsync(x => x.Name == name && x.ClusterId == clusterId);
    }

    public async Task<List<NameSpace>> GetNameSpaceByIdsListAsync(List<string> ids)
    {
        return await this.FindAll(x => ids.Contains(x.Id)).ToListAsync();
    }


    public async Task<NameSpace?> FindNameSpaceByIdAsync(string id)
    {
        return await this.FindAll().FirstOrDefaultAsync(x => x.Id == id);
    }


    /// <summary>
    /// 获取NameSpace列表
    /// </summary>
    /// <returns></returns>
    public Task<List<NameSpace>> GetNameSpaceListAsync() => FindAll().ToListAsync();

}