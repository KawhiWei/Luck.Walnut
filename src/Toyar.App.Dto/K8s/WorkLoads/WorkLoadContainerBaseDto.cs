namespace Toyar.App.Dto.K8s.WorkLoads;

public class WorkLoadContainerBaseDto
{
    /// <summary>
    /// 容器名称
    /// </summary>
    public string ContainerName { get; set; } = default!;

    /// <summary>
    /// 重启策略
    /// </summary>

    public string RestartPolicy { get; set; } = default!;
    
    /// <summary>
    /// 镜像拉取策略
    /// </summary>
    public string ImagePullPolicy { get; set; } = default!;

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string? Image { get; set; }
    public WorkLoadContainerPluginDto WorkLoadContainerPlugins { get; set; } = default!;

}