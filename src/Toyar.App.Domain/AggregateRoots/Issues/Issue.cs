
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.Issues;

/// <summary>
/// 事项
/// </summary>
public class Issue: FullAggregateRoot
{
    public Issue(string name, string describe, string projectId, ComplexityEnum complexity, PriorityLevelEnum priorityLevel, string productPrincipal, string mainProductManager, string productAim, MatterTypeEnum matterType, DateOnly planOnlineTime, List<string> productManagers)
    {
        Name = name;
        Describe = describe;
        ProjectId = projectId;
        Complexity = complexity;
        PriorityLevel = priorityLevel;
        ProductPrincipal = productPrincipal;
        MainProductManager = mainProductManager;
        ProductAim = productAim;
        MatterType = matterType;
        PlanOnlineTime = planOnlineTime;
        ProductManagers = productManagers;
    }

    /// <summary>
    /// 需求名称
    /// </summary>
    public string Name { get; private set; } 
    
    /// <summary>
    /// 需求描述
    /// </summary>
    public string Describe { get; private set; } 
    
    /// <summary>
    /// 项目id
    /// </summary>
    /// <returns></returns>
    public  string ProjectId { get; private set; } 

    /// <summary>
    /// 复杂度
    /// </summary>
    public ComplexityEnum Complexity  { get; private set; } 

    /// <summary>
    /// 优先级
    /// </summary>
    public PriorityLevelEnum PriorityLevel { get; private set; } 
    
    /// <summary>
    /// 产品负责人
    /// </summary>
    public  string ProductPrincipal{ get; private set; } 
    
    /// <summary>
    /// 主产品经理
    /// </summary>
    public string MainProductManager{ get; private set; } 
    
    /// <summary>
    /// 产品目标
    /// </summary>
    public  string ProductAim{ get; private set; } 
    
    /// <summary>
    /// 事项类型
    /// </summary>
    /// <returns></returns>
    public MatterTypeEnum MatterType { get; private set; } 
    
    /// <summary>
    /// 计划上线时间
    /// </summary>
    public DateOnly PlanOnlineTime { get; private set; } 
    
    /// <summary>
    /// 产品经理
    /// </summary>
    public List<string> ProductManagers{ get; private set; } 
}