using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Query.BuildImages;

public class BuildImageVersionQueryService : IBuildImageVersionQueryService
{
    private readonly IBuildImageVersionRepository _buildImageVersionRepository;

    public BuildImageVersionQueryService(IBuildImageVersionRepository buildImageVersionRepository)
    {
        _buildImageVersionRepository = buildImageVersionRepository;
    }

    public Task<List<BuildImageVersionOutputDto>> FindListAsync(string imageId)
    {
        return _buildImageVersionRepository.FindListAsync(imageId);
    }
}