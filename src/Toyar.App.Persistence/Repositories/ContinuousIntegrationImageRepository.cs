using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Persistence.Repositories;

public class ContinuousIntegrationImageRepository : EfCoreAggregateRootRepository<ContinuousIntegrationImage, string>, IContinuousIntegrationImageRepository
{
    public ContinuousIntegrationImageRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ContinuousIntegrationImage> FindFirstByIdAsync(string id)
    {
        var buildImage = await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if (buildImage is null)
        {
            throw new BusinessException($"镜像不存在");
        }

        return buildImage;
    }

    public async Task<ContinuousIntegrationImage?> FindFirstByNameAsync(string name)
    {
        var buildImage = await FindAll(x =>x.Name == name).FirstOrDefaultAsync();
        return buildImage ?? null;
    }

    public async Task<(ContinuousIntegrationImageOutputDto[] Data, int TotalCount)> GetBuildImagePageListAsync(ContinuousIntegrationImagesQueryDto query)
    {
        var queryable = FindAll().Select(x => new ContinuousIntegrationImageOutputDto
        {
            Id = x.Id,
            CompileScript = x.RegistryUrl,
            Name = x.Name
        }).WhereIf(x => x.BuildImageName.Contains(query.BuildImageName), !query.BuildImageName.IsNullOrWhiteSpace())
        .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
        .OrderBy(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }
}