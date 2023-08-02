
using Toyar.App.Dto.K8s.NameSpaces;

namespace Toyar.App.AppService.K8s.NameSpaces;

public interface INameSpaceService : IScopedDependency
{
    /// <summary>
    /// 创建名称空间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task CreateNameSpaceAsync(NameSpaceInputDto input);

    /// <summary>
    /// 修改名称空间
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    Task UpdateNameSpaceAsync(string id, NameSpaceInputDto input);

    /// <summary>
    /// 发布名称空间
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task OnlineNameSpaceAsync(string id);

    Task OfflineNameSpaceAsync(string id);

    /// <summary>
    /// 删除名称空间
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteNameSpaceAsync(string id);
}