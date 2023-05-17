using Luck.Framework.Extensions;

namespace Toyar.App.Dto.ComponentIntegrations;

public class ComponentIntegrationOutputDto : ComponentIntegrationBaseDto
{
    /// <summary>
    /// 唯一Id
    /// </summary>
    public string Id { get; set; } = default!;

    public string ComponentLinkTypeName => ComponentType.ToDescription();


    public string ComponentCategoryName => ComponentCategory.ToDescription();
}