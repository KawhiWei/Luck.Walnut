using Luck.Framework.Extensions;

namespace Toyar.App.Dto.Deployments;

public class DeploymentOutputDto : DeploymentBaseDto
{
    public string Id { get; set; } = default!;

    public string ClusterName { get; set; } = default!;


    /// <summary>
    /// 部署更新策略
    /// </summary>
    public DeploymentPluginsDto DeploymentPlugins { get; set; } = default!;
    public string DeploymentTypeName => DeploymentType.ToDescription();



    public string ApplicationRuntimeTypeName => ApplicationRuntimeType.ToDescription();
}
