using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 流水线状态枚举
/// </summary>
public enum PipelineBuildStateEnum
{
    /// <summary>
    /// 准备完成
    /// </summary>
    [Description("准备完成")] Ready = 0,

    /// <summary>
    /// 执行中
    /// </summary>
    [Description("执行中")] Running = 1,

    /// <summary>
    /// 成功
    /// </summary>
    [Description("成功")] Success = 2,

    /// <summary>
    /// 失败
    /// </summary>
    [Description("失败")] Fail = 3,
}