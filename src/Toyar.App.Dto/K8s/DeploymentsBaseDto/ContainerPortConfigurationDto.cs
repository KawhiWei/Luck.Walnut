namespace Toyar.App.Dto.K8s.DeploymentsBaseDto;

public class ContainerPortConfigurationDto
{
    /// <summary>
    /// 端口名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 容器端口
    /// </summary>
    public uint? ContainerPort { get; set; }

    /// <summary>
    /// 端口协议
    /// </summary>
    public string? Protocol { get; set; }
}