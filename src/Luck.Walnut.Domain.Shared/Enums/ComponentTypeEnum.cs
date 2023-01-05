using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 集成组件类型枚举
/// </summary>
public enum ComponentTypeEnum
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

    /// <summary>
    /// 阿里云镜像仓库
    /// </summary>
    [Description("阿里云镜像仓库")] AliImageWarehouse = 5,
}

/// <summary>
/// 集成组件分类枚举
/// </summary>
public enum ComponentCategoryEnum
{
    /// <summary>
    /// 代码仓库
    /// </summary>
    [Description("代码仓库")] CodeWarehouse = 1,

    /// <summary>
    /// 流水线组件
    /// </summary>
    [Description("流水线")] PipeLine = 2,

    /// <summary>
    /// 镜像仓库
    /// </summary>
    [Description("镜像仓库")] ImageWarehouse = 3,
}