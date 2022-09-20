using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.Projects;

public class ProjectOutputDto:ProjectBaseDto
{
    public string ProjectStatusName => ProjectStatus.ToDescription();
}