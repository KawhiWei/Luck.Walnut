using Luck.EntityFrameworkCore.DbContexts;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Persistence.Repositories;

public class BuildImageVersionRepository : EfCoreEntityRepository<ContinuousIntegrationImageVersion, string>, IBuildImageVersionRepository
{
    public BuildImageVersionRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }


    public Task<List<ContinuousIntegrationImageVersionOutputDto>> FindListAsync(string imaneId) => FindAll(x => x.ContinuousIntegrationImageId == imaneId)
        .Select(x => new ContinuousIntegrationImageVersionOutputDto()
        {
            Id = x.Id,
            Version = x.Version,
            BuildImageId = x.ContinuousIntegrationImageId,
        }).ToListAsync();
}