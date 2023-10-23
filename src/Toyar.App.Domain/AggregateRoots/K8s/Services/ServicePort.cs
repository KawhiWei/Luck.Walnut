using System.Text.Json.Serialization;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.K8s.Services;

public class ServicePort
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="portType"></param>
    /// <param name="portName"></param>
    /// <param name="sourcePort"></param>
    /// <param name="targetPort"></param>
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public ServicePort(PortTypeEnum portType, string portName, uint sourcePort, uint targetPort)
    {
        PortType = portType;
        PortName = portName;
        SourcePort = sourcePort;
        TargetPort = targetPort;
    }

    /// <summary>
    /// 端口类型
    /// </summary>
    public PortTypeEnum PortType { get; private set; }

    /// <summary>
    /// 服务名称
    /// </summary>
    public string PortName { get; private set; }

    /// <summary>
    /// 来源端口号
    /// </summary>
    public uint SourcePort { get; private set; }

    /// <summary>
    /// 目的端口号
    /// </summary>
    public uint TargetPort { get; private set; }
}