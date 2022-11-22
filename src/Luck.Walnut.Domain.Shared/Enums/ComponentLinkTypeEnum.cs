using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 集成组件类型枚举
/// </summary>
public enum ComponentLinkTypeEnum
{
    /// <summary>
    /// Gitlab
    /// </summary>
    [Description("Gitlab代码仓库")] Gitlab = 1,

    /// <summary>
    /// Gitlab
    /// </summary>
    [Description("Gogs代码仓库")] Gogs = 2,

    /// <summary>
    /// Harbor
    /// </summary>
    [Description("Harbor镜像仓库")] Harbor = 3,

    /// <summary>
    /// Jenkins
    /// </summary>
    [Description("Jenkins流水线引擎")] Jenkins = 4,
}