using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Query.ContinuousIntegrationImages;

public class BuildImageVersionQueryService : IBuildImageVersionQueryService
{
    private readonly IBuildImageVersionRepository _buildImageVersionRepository;

    public BuildImageVersionQueryService(IBuildImageVersionRepository buildImageVersionRepository)
    {
        _buildImageVersionRepository = buildImageVersionRepository;
    }

    public Task<List<ContinuousIntegrationImageVersionOutputDto>> FindListAsync(string imageId)
    {
        return _buildImageVersionRepository.FindListAsync(imageId);
    }
}