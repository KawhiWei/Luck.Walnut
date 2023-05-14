using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Persistence.Repositories;

public class BuildImageRepository : EfCoreAggregateRootRepository<BuildImage, string>, IBuildImageRepository
{
    public BuildImageRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<BuildImage> FindFirstByIdAsync(string id)
    {
        var buildImage = await FindAll(x => x.Id == id).FirstOrDefaultAsync();
        if (buildImage is null)
        {
            throw new BusinessException($"镜像不存在");
        }

        return buildImage;
    }

    public async Task<BuildImage?> FindFirstByNameAsync(string name)
    {
        var buildImage = await FindAll(x =>x.Name == name).FirstOrDefaultAsync();
        return buildImage ?? null;
    }

    public async Task<(BuildImagesOutputDto[] Data, int TotalCount)> GetBuildImagePageListAsync(BuildImagesQueryDto query)
    {
        var queryable = FindAll().Select(x => new BuildImagesOutputDto
        {
            Id = x.Id,
            CompileScript = x.CompileScript,
            BuildImageName = x.BuildImageName,
            Name = x.Name
        }).WhereIf(x => x.BuildImageName.Contains(query.BuildImageName), !query.BuildImageName.IsNullOrWhiteSpace())
        .WhereIf(x => x.Name.Contains(query.Name), !query.Name.IsNullOrWhiteSpace())
        .OrderBy(x => x.Id);
        var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
        var totalCount = await queryable.CountAsync();
        return (list, totalCount);
    }
}