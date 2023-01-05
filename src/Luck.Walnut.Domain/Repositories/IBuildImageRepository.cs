using Luck.Walnut.Domain.AggregateRoots.BuildImages;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.BuildImages;

namespace Luck.Walnut.Domain.Repositories;

public interface IBuildImageRepository : IAggregateRootRepository<BuildImage, string>, IScopedDependency
{
    /// <summary>
    /// 根据项目id获取项目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BuildImage> FindFirstByIdAsync(string id);

    /// <summary>
    /// 根据镜像名称获取镜像
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<BuildImage?> FindFirstByNameAsync(string name);

    Task<(BuildImagesOutputDto[] Data, int TotalCount)> GetBuildImagePageListAsync(BuildImagesQueryDto query);
}