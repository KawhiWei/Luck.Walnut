using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

public enum ProjectStatusEnum
{
    /// <summary>
    /// 未开始
    /// </summary>
    [Description("未开始")]
    UnStart=0,
    
    /// <summary>
    /// 进行中
    /// </summary>
    [Description("进行中")]
    Actity=5,
    
    /// <summary>
    /// 已暂停
    /// </summary>
    [Description("已暂停")]
    Suspended=10,
    
    /// <summary>
    /// 已结束
    /// </summary>
    [Description("已结束")]
    End=15,
}