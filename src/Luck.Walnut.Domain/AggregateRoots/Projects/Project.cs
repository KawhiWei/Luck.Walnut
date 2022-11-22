using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Projects;

public class Project : FullAggregateRoot
{
    public Project(string name, string projectPrincipal, ProjectStatusEnum projectStatus, DateOnly planStartTime, DateOnly? planEndTime, string? describe)
    {
        Name = name;
        ProjectPrincipal = projectPrincipal;
        ProjectStatus = projectStatus;
        PlanStartTime = planStartTime;
        PlanEndTime = planEndTime;
        Describe = describe;
    }

    /// <summary>
    /// 需求名称
    /// </summary>
    public string Name { get; private set; }




    /// <summary>
    /// 项目负责人
    /// </summary>
    public string ProjectPrincipal { get; private set; }
    
    /// <summary>
    /// 项目状态
    /// </summary>
    public ProjectStatusEnum ProjectStatus { get; private set; }
    
    /// <summary>
    /// 计划开始时间
    /// </summary>
    public DateOnly PlanStartTime { get; private set; }
    
    /// <summary>
    /// 计划结束时间
    /// </summary>
    public DateOnly? PlanEndTime { get; private set; }
    
    /// <summary>
    /// 需求描述
    /// </summary>
    public string? Describe { get; private set; }

    public Project UpdateInfo(string name, string projectPrincipal, ProjectStatusEnum projectStatus, DateOnly planStartTime, DateOnly? planEndTime, string? describe)
    {
        Name = name;
        ProjectPrincipal = projectPrincipal;
        ProjectStatus = projectStatus;
        PlanStartTime = planStartTime;
        PlanEndTime = planEndTime;
        Describe = describe;
        return this;
    }
    

}