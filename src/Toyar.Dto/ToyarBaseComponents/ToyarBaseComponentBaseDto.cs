using Toyar.Infrastructure.Enums;

namespace Toyar.Dto.ToyarBaseComponents;

public class ToyarBaseComponentBaseDto
{
    /// <summary>
    /// 组件英文名称
    /// </summary>
    public string EnglishName { get; set; } = string.Empty;

    /// <summary>
    /// 组件中文名称
    /// </summary>
    public string ChinesName { get; private set; } = string.Empty;

    /// <summary>
    /// 组件Url地址
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 凭证类型
    /// </summary>
    public CertificateTypeEnum CertificateType { get; set; }

    /// <summary>
    /// 凭证
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// 账号
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = string.Empty;
}