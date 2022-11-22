using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.ComponentIntegrations;

namespace Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;

/// <summary>
/// 支撑组件连接管理
/// </summary>
public class ComponentIntegration : FullAggregateRoot
{
    public ComponentIntegration()
    {
    }


    public ComponentIntegration(string name, ComponentLinkTypeEnum componentLinkType,Credential credential)
    {
        Name = name;
        ComponentLinkType = componentLinkType;
        Credential = credential;
    }

    /// <summary>
    /// 组件名称
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// 组件类型
    /// </summary>
    public ComponentLinkTypeEnum ComponentLinkType { get; private set; }

    /// <summary>
    /// 凭证列表
    /// </summary>
    public Credential Credential { get; private set; } 

    /// <summary>
    /// 设置Credential值对象
    /// </summary>
    /// <param name="componentLinkUrl"></param>
    /// <param name="userName"></param>
    /// <param name="passWord"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public ComponentIntegration SetCredential(string componentLinkUrl,string? userName, string? passWord, string? token)
    {
        Credential = new Credential(componentLinkUrl,userName, passWord, token);
        return this;
    }
    
    /// <summary>
    /// 设置组件类型
    /// </summary>
    /// <param name="componentLinkType"></param>
    /// <returns></returns>
    public ComponentIntegration SetComponentLinkType(ComponentLinkTypeEnum componentLinkType)
    {
        ComponentLinkType = componentLinkType;
        return this;
    }
}