using System.ComponentModel;

namespace Toyar.App.Domain.Shared.Enums;

/// <summary>
/// 复杂度枚举
/// </summary>
public enum ComplexityEnum
{
    /// <summary>
    /// 简单
    /// </summary>
    [Description("简单")] Simple = 1,

    /// <summary>
    /// 一般
    /// </summary>
    [Description("一般")] Commonly = 5,

    /// <summary>
    /// 
    /// </summary>
    [Description("复杂")] Complex = 10
}