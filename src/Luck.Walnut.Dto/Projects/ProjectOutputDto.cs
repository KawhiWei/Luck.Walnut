using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.Projects;

public class ProjectOutputDto:ProjectBaseDto
{
    /// <summary>
    /// 唯一Id
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string ProjectStatusName => ProjectStatus.ToDescription();
}