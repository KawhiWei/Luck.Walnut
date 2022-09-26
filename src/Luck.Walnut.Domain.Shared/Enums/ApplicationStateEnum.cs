using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

public enum ApplicationStateEnum
{
    /// <summary>
    /// 未开始
    /// </summary>
    [Description("未开始")] NotStart = 0,
    
    /// <summary>
    /// 开发中
    /// </summary>
    [Description("开发中")] UnderDevelopment = 5,
    
    /// <summary>
    /// 未上线
    /// </summary>
    [Description("开发完成未发布")] NotOnline = 10,

    /// <summary>
    /// 线上运行中
    /// </summary>
    [Description("线上运行中")] OnlineRunning = 15,

    /// <summary>
    /// 已下线
    /// </summary>
    [Description("已下线")] Offline = 20,
}