using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 任务类型
/// </summary>
public enum AssignmentTypeEnum
{
    
    /// <summary>
    /// 开发任务
    /// </summary>
    [Description("开发任务")]
    DevelopmentTask=1,
    
    /// <summary>
    /// 非开发任务
    /// </summary>
    [Description("非开发任务")]
    NonDevelopmentTask=5,
}