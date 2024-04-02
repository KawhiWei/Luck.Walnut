using System.ComponentModel;

namespace Toyar.Infrastructure;

/// <summary>
/// 部署类型
/// </summary>
public enum DeployTypeEnum
{
    [Description("Docker")] Docker = 1,

    [Description("Kubernetes")] Kubernetes = 2,
}