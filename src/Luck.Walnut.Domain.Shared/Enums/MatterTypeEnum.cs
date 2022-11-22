using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 事项类型
/// </summary>
public enum MatterTypeEnum
{
    /// <summary>
    /// 产品需求
    /// </summary>
    [Description("产品事项")] Product = 1,

    /// <summary>
    /// 插入事项
    /// </summary>
    [Description("插入事项")] Insert = 5,

    /// <summary>
    /// 技术事项
    /// </summary>
    [Description("技术事项")] Technology = 10,
}