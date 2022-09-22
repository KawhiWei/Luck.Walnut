
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.Projects;

public abstract class ProjectBaseDto
{
    /// <summary>
    /// 需求名称
    /// </summary>
    public string Name { get;  set; }

    /// <summary>
    /// 需求描述
    /// </summary>
    public string? Describe { get;  set; }


    /// <summary>
    /// 项目负责人
    /// </summary>
    public string ProjectPrincipal { get;  set; }
    
    /// <summary>
    /// 项目状态
    /// </summary>
    public ProjectStatusEnum ProjectStatus { get;  set; }
    
    /// <summary>
    /// 计划开始时间
    /// </summary>
    public DateOnly PlanStartTime { get;  set; }
    
    /// <summary>
    /// 计划结束时间
    /// </summary>
    public DateOnly? PlanEndTime { get;  set; }
}