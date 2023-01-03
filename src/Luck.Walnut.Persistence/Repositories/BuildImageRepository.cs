using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Exceptions;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Domain.Repositories;

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
            throw new BusinessException($"流水线不存在");
        }

        return buildImage;
    }
}