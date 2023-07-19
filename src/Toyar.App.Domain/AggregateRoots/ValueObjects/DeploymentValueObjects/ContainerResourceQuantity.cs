using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

/// <summary>
/// 资源配置
/// </summary>
public class ContainerResourceQuantity
{
    [JsonConstructor] //这个特性 可以写私有，标识你要用哪个构造函数
    public ContainerResourceQuantity(string cpu, string memory)
    {
        Cpu = cpu;
        Memory = memory;
    }

    public string Cpu { get; private set; } = default!;
    public string Memory { get; private set; } = default!;

    public ContainerResourceQuantity SetCpu(string cpu)
    {
        Cpu = cpu;
        return this;
    }

    public ContainerResourceQuantity SetMemory(string memory)
    {
        Memory = memory;
        return this;
    }
}