using Toyar.Infrastructure;
using Toyar.Infrastructure.Enums;

namespace Toyar.Domain.AggregateRoots.BaseComponents;

public class ToyarBaseComponent : FullAggregateRoot
{
    public ToyarBaseComponent(string englishName, string chinesName, string url, CertificateTypeEnum certificateType,
        string token, string account, string password)
    {
        EnglishName = englishName;
        ChinesName = chinesName;
        Url = url;
        CertificateType = certificateType;
        Token = token;
        Account = account;
        Password = password;
    }

    /// <summary>
    /// 英文名称
    /// </summary>
    public string EnglishName { get; private set; }

    /// <summary>
    /// 中文名称
    /// </summary>
    public string ChinesName { get; private set; }

    /// <summary>
    /// 组件Url地址
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// 凭证类型
    /// </summary>
    public CertificateTypeEnum CertificateType { get; set; }

    /// <summary>
    /// 凭证
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUserName { get; private set; } = ToyarDefaultConstants.DefaultUserName;

    /// <summary>
    /// 创建人Id
    /// </summary>
    public string CreateUserId { get; private set; } = ToyarDefaultConstants.DefaultUserId;

    /// <summary>
    /// 最后修改人
    /// </summary>
    public string LastModificationUserName { get; private set; } = ToyarDefaultConstants.DefaultUserName;

    /// <summary>
    /// 最后修改人Id
    /// </summary>
    public string LastModificationUserId { get; private set; } = ToyarDefaultConstants.DefaultUserId;
}