using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.Issues;

public abstract class IssueBaseDto
{
    /// <summary>
    /// 需求名称
    /// </summary>
    public string Name { get;  set; }  = default!;
    
    /// <summary>
    /// 需求描述
    /// </summary>
    public string Describe { get;  set; }  = default!;
    
    /// <summary>
    /// 需求业务线
    /// </summary>
    /// <returns></returns>
    public  string ProjectId { get;  set; }  = default!;

    /// <summary>
    /// 复杂度
    /// </summary>
    public ComplexityEnum Complexity  { get;  set; } 

    /// <summary>
    /// 优先级
    /// </summary>
    public PriorityLevelEnum PriorityLevel { get;  set; } 
    
    /// <summary>
    /// 产品负责人
    /// </summary>
    public  string ProductPrincipal{ get;  set; }  = default!;
    
    /// <summary>
    /// 主产品经理
    /// </summary>
    public string MainProductManager{ get;  set; }  = default!;
    
    /// <summary>
    /// 产品目标
    /// </summary>
    public  string ProductAim{ get;  set; }  = default!;
    
    /// <summary>
    /// 事项类型
    /// </summary>
    /// <returns></returns>
    public MatterTypeEnum MatterType { get;  set; } 
    
    /// <summary>
    /// 计划上线时间
    /// </summary>
    public DateOnly PlanOnlineTime { get;  set; }
    
    /// <summary>
    /// 产品经理
    /// </summary>
    public List<string> ProductManagers{ get;  set; }  = default!;
}