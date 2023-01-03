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
    
    
}