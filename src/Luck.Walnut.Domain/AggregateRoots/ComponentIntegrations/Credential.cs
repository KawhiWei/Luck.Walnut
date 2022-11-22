using System.Text.Json.Serialization;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;

public class Credential
{
    
    public Credential()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="passWord"></param>
    /// <param name="token"></param>
    /// <param name="componentLinkUrl"></param>
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public Credential(string componentLinkUrl,string? userName, string? passWord, string? token)
    {
        ComponentLinkUrl = componentLinkUrl;
        UserName = userName;
        PassWord = passWord;
        Token = token;
    }

    /// <summary>
    /// 组件链接地址
    /// </summary>
    public string ComponentLinkUrl { get;  private set; }= default!;
    
    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; private set; } = default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? PassWord { get;  private set;}= default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? Token { get;  private set; }= default!;
}