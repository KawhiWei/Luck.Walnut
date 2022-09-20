using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.Issues;

public class IssueOutputDto : IssueBaseDto
{

    /// <summary>
    /// 复杂度
    /// </summary>
    public string ComplexityName => Complexity.ToDescription();
    
    /// <summary>
    /// 优先级
    /// </summary>
    public string PriorityLevelName => PriorityLevel.ToDescription();
}