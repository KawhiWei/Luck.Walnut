using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ComponentIntegrations;

public class ComponentIntegrationBaseDto
{
    /// <summary>
    /// 组件名称
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 组件类型
    /// </summary>
    public ComponentTypeEnum ComponentType { get; set; }

    /// <summary>
    /// 组件类型
    /// </summary>
    public ComponentCategoryEnum ComponentCategory { get; set; }

    /// <summary>
    /// 组件链接地址
    /// </summary>
    public string ComponentLinkUrl { get; set; } = default!;

    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; } = default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? PassWord { get; set; } = default!;

    /// <summary>
    /// 密码
    /// </summary>
    public string? Token { get; set; } = default!;
}

public class DockerRegistry
{
    public Dictionary<string, AuthDto> Auths { get; set; } = default!;
}

public class AuthDto
{
    public string Auth{ get; set; } = default!;
}