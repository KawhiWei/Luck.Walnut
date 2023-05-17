using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.ComponentIntegrations;

public class ComponentIntegrationQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 组件名称
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// 组件类型
    /// </summary>
    public ComponentTypeEnum? ComponentLinkType { get; set; }
}