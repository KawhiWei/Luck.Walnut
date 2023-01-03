using Luck.EntityFrameworkCore.DbContexts;
using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Persistence.Repositories;

public class BuildImageVersionRepository : EfCoreEntityRepository<BuildImageVersion, string>, IBuildImageVersionRepository
{
    public BuildImageVersionRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }


    public Task<List<BuildImageVersionOutputDto>> FindListAsync(string imaneId) => FindAll(x => x.BuildImageId == imaneId)
        .Select(x => new BuildImageVersionOutputDto()
        {
            Id = x.Id,
            Version = x.Version,
            BuildImageId = x.BuildImageId,
        }).ToListAsync();
}