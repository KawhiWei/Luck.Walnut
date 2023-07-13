using Toyar.App.Dto;
using Toyar.App.Dto.Deployments;

namespace Toyar.App.Query.Deployments;

public interface IDeploymentQueryService : IScopedDependency
{
    Task<DeploymentOutputDto> GetDeploymentForIdAsync(string id);


    Task<PageBaseResult<DeploymentOutputDto>> GetDeploymentPageListAsync(string appId, DeploymentQueryDto query);
}
