using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

public enum ComponentLinkTypeEnum
{
    /// <summary>
    /// Gitlab
    /// </summary>
    [Description("Gitlab")] Gitlab = 1,

    /// <summary>
    /// Gitlab
    /// </summary>
    [Description("Gogs")] Gogs = 2,

    /// <summary>
    /// Harbor
    /// </summary>
    [Description("Harbor镜像仓库")] Harbor = 3,

    /// <summary>
    /// Jenkins
    /// </summary>
    [Description("Jenkins流水线引擎")] Jenkins = 4,
}