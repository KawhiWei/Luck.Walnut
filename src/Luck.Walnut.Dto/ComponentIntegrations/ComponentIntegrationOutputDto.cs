using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.ComponentIntegrations;

public class ComponentIntegrationOutputDto : ComponentIntegrationBaseDto
{
    /// <summary>
    /// 唯一Id
    /// </summary>
    public string Id { get; set; } = default!;

    public string ComponentLinkTypeName => ComponentLinkType.ToDescription();
}