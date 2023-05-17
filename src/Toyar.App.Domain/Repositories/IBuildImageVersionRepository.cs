using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Domain.Repositories;

public interface IBuildImageVersionRepository:IEntityRepository<ContinuousIntegrationImageVersion,string>,IScopedDependency
{
    Task<List<ContinuousIntegrationImageVersionOutputDto>> FindListAsync(string imaneId);

}