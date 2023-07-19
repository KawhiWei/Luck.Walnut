namespace Toyar.App.Dto.ValueObjects.DeploymentValueObjects;

public class ContainerPortConfigurationDto
{
    /// <summary>
    /// 端口名称
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 容器端口
    /// </summary>
    public uint ContainerPort { get; set; } = default!;

    /// <summary>
    /// 端口协议
    /// </summary>
    public string Protocol { get; set; } = default!;
}