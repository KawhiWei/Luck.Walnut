using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Domain.Repositories;

public interface IBuildImageVersionRepository:IEntityRepository<BuildImageVersion,string>,IScopedDependency
{
    Task<List<BuildImageVersionOutputDto>> FindListAsync(string imaneId);

}