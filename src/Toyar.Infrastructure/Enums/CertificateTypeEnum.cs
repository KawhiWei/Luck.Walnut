using System.ComponentModel;

namespace Toyar.Infrastructure.Enums;

/// <summary>
/// 凭证类型枚举
/// </summary>
public enum CertificateTypeEnum
{
    /// <summary>
    /// 无模式
    /// </summary>
    [Description("无模式")] None = 0,
    /// <summary>
    /// 授权码模式
    /// </summary>
    [Description("授权码模式")] AuthorizationCode = 1,

    /// <summary>
    /// 密码模式
    /// </summary>
    [Description("密码模式")] Password = 2,
}