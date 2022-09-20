using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

public enum ApplicationStatusEnum
{
    /// <summary>
    /// 未上线
    /// </summary>
    [Description("未上线")] NotOnline = 0,

    /// <summary>
    /// 开发中
    /// </summary>
    [Description("开发中")] UnderDevelopment = 5,

    /// <summary>
    /// 线上运行中
    /// </summary>
    [Description("线上运行中")] OnlineRunning = 10,

    /// <summary>
    /// 已下线
    /// </summary>
    [Description("已下线")] Offline = 10,
}