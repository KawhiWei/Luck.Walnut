using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Dto;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Domain.Repositories;

public interface IContinuousIntegrationImageRepository : IAggregateRootRepository<ContinuousIntegrationImage, string>, IScopedDependency
{
    /// <summary>
    /// 根据项目id获取项目
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ContinuousIntegrationImage> FindFirstByIdAsync(string id);

    /// <summary>
    /// 根据镜像名称获取镜像
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<ContinuousIntegrationImage?> FindFirstByNameAsync(string name);

    Task<(ContinuousIntegrationImageOutputDto[] Data, int TotalCount)> GetBuildImagePageListAsync(ContinuousIntegrationImagesQueryDto query);
}