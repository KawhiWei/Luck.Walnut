﻿using System.ComponentModel;

namespace Toyar.App.Domain.Shared.Enums
{
    /// <summary>
    /// 在线状态枚举
    /// </summary>
    public enum OnlineStatusEnum
    {
        /// <summary>
        /// 上线
        /// </summary>
        [Description("上线")]
        Online = 0,

        /// <summary>
        /// 下线
        /// </summary>
        [Description("下线")]
        Offline = 5,
    }
}
