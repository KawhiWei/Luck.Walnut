using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Query.ContinuousIntegrationImages;

public interface IBuildImageVersionQueryService : IScopedDependency
{
    Task<List<ContinuousIntegrationImageVersionOutputDto>> FindListAsync(string imageId);
}