using Toyar.App.Dto.K8s.DeploymentsBaseDto;

namespace Toyar.App.Dto.DeploymentConfigurations;

public class MasterContainerConfigurationBaseDto
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
    /// 是否初始容器
    /// </summary>
    public bool IsInitContainer { get; set; }

    /// <summary>
    /// 镜像拉取策略
    /// </summary>

    public string ImagePullPolicy { get; set; } = default!;

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// 准备完成探针配置
    /// </summary>
    public ContainerSurviveConfigurationDto? ReadinessProbe { get; set; }

    /// <summary>
    /// 存活探针配置
    /// </summary>
    public ContainerSurviveConfigurationDto? LiveNessProbe { get; set; }

    /// <summary>
    /// 容器Cpu资源限制
    /// </summary>
    public ContainerResourceQuantityDto? Limits { get; set; }

    /// <summary>
    /// 容器内存资源限制
    /// </summary>
    public ContainerResourceQuantityDto? Requests { get; set; }

    /// <summary>
    /// 环境变量
    /// </summary>
    public List<KeyValuePair<string, string>>? Environments { get; set; }


    /// <summary>
    /// 容器端口配置
    /// </summary>
    public List<ContainerPortConfigurationDto>? ContainerPortConfigurations { get; set; } = null;
}

