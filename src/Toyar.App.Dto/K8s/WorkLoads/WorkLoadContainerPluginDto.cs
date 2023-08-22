using Toyar.App.Dto.ValueObjects.WorkLoadValueObjects;

namespace Toyar.App.Dto.K8s.WorkLoads;

/// <summary>
/// 
/// </summary>
public class WorkLoadContainerPluginDto
{
    /// <summary>
    /// 准备完成探针配置
    /// </summary>
    public ContainerSurviveConfigurationDto? ReadNess { get; set; }

    /// <summary>
    /// 存活探针配置
    /// </summary>
    public ContainerSurviveConfigurationDto? LiveNess { get; set; }

    /// <summary>
    /// 容器Cpu资源限制
    /// </summary>
    public ContainerResourceQuantityDto? Limit { get; set; }

    /// <summary>
    /// 容器内存资源限制
    /// </summary>
    public ContainerResourceQuantityDto? Request { get; set; }

    /// <summary>
    /// 环境变量
    /// </summary>
    public Dictionary<string, string> Env { get; set; } = new();
    
    /// <summary>
    /// 容器端口配置
    /// </summary>
    public List<ContainerPortDto> ContainerPorts { get; set; } = new();
}