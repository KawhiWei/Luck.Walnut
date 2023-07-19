using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

/// <summary>
/// 容器端口配置
/// </summary>
public class ContainerPortConfiguration
{
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public ContainerPortConfiguration(string name, uint containerPort, string protocol)
    {
        Name = name;
        ContainerPort = containerPort;
        Protocol = protocol;
    }

    /// <summary>
    /// 端口名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 容器端口
    /// </summary>
    public uint ContainerPort { get; private set; }

    /// <summary>
    /// 端口协议
    /// </summary>
    public string Protocol { get; private set; }
}