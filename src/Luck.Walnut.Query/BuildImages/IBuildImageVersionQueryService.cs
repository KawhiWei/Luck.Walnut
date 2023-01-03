using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Query.BuildImages;

public interface IBuildImageVersionQueryService : IScopedDependency
{
    Task<List<BuildImageVersionOutputDto>> FindListAsync(string imageId);
}