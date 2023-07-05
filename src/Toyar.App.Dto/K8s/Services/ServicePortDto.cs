

using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.K8s.Services;

public class ServicePortDto
{
    /// <summary>
    /// 端口类型
    /// </summary>
    public PortTypeEnum PortType { get; set; } = default!;

    /// <summary>
    /// 服务名称
    /// </summary>
    public string PortName { get; set; } = default!;

    /// <summary>
    /// 来源端口号
    /// </summary>
    public uint SourcePort { get; set; } = default!;

    /// <summary>
    /// 目的端口号
    /// </summary>
    public uint TargetPort { get; set; } = default!;
}