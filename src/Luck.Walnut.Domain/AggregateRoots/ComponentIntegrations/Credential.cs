using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;

public class Credential
{
    
    public Credential()
    {
    }

    public Credential(string userName, string passWord, string token, string componentLinkUrl)
    {
        UserName = userName;
        PassWord = passWord;
        Token = token;
        ComponentLinkUrl = componentLinkUrl;
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; private set; } = default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string PassWord { get; private set; }= default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string Token { get; private set; }= default!;
    
    /// <summary>
    /// 组件链接地址
    /// </summary>
    public string ComponentLinkUrl { get; private set; }= default!;
}