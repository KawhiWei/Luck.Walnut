using Toyar.App.Dto.Deployments;

namespace Toyar.App.AppService.Deployments;

public interface IDeploymentService : IScopedDependency
{
    Task CreateDeploymentAsync(DeploymentInputDto input);


    Task UpdateDeploymentAsync(string id, DeploymentInputDto input);


    /// <summary>
    /// 部署应用
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imageVersion"></param>
    /// <returns></returns>
    Task DeployApplicationAsync(string id, string imageVersion);

    Task DeleteDeploymentAsync(string id);
}
