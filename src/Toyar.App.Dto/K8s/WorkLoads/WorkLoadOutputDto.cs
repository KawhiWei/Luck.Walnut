using Luck.Framework.Extensions;

namespace Toyar.App.Dto.K8s.WorkLoads;

public class WorkLoadOutputDto : WorkLoadBaseDto
{
    public string Id { get; set; } = default!;

    public string ClusterName { get; set; } = default!;


    /// <summary>
    /// 部署更新策略
    /// </summary>
    public WorkLoadPluginsDto WorkLoadPlugins { get; set; } = default!;

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool IsPublish { get; set; }

    public string DeploymentTypeName => DeploymentType.ToDescription();

    public string ApplicationRuntimeTypeName => ApplicationRuntimeType.ToDescription();
}
