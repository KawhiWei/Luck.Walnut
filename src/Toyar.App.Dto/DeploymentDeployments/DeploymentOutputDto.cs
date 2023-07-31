using Luck.Framework.Extensions;

namespace Toyar.App.Dto.Deployments;

public class DeploymentOutputDto : DeploymentBaseDto
{
    public string Id { get; set; } = default!;

    public string ClusterName { get; set; } = default!;


    public string deploymentTypeName => DeploymentType.ToDescription();



    public string ApplicationRuntimeTypeName => ApplicationRuntimeType.ToDescription();
}
