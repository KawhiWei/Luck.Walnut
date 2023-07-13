using Toyar.App.Dto.Deployments;

namespace Toyar.App.AppService.Deployments;

public interface IDeploymentService : IScopedDependency
{
    Task CreateDeploymentAsync(DeploymentInputDto input);


    Task UpdateDeploymentAsync(string id, DeploymentInputDto input);



    Task DeleteDeploymentAsync(string id);
}
