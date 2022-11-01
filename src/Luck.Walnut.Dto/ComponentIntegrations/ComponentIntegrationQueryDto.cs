using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ComponentIntegrations;

public class ComponentIntegrationQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 组件名称
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// 组件类型
    /// </summary>
    public ComponentLinkTypeEnum? ComponentLinkType { get; set; }
}