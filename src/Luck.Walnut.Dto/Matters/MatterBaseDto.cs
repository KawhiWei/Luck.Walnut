using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.Matters;

public abstract class MatterBaseDto
{
    /// <summary>
    /// 需求名称
    /// </summary>
    public string Name { get;  set; } 
    
    /// <summary>
    /// 需求描述
    /// </summary>
    public string Describe { get;  set; } 
    
    /// <summary>
    /// 需求业务线
    /// </summary>
    /// <returns></returns>
    public  string BusinessLine { get;  set; } 

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
    public  string ProductPrincipal{ get;  set; } 
    
    /// <summary>
    /// 主产品经理
    /// </summary>
    public string MainProductManager{ get;  set; } 
    
    /// <summary>
    /// 产品目标
    /// </summary>
    public  string ProductAim{ get;  set; } 
    
    /// <summary>
    /// 事项类型
    /// </summary>
    /// <returns></returns>
    public MatterTypeEnum MatterType { get;  set; } 
    
    /// <summary>
    /// 计划上线时间
    /// </summary>
    public DateTimeOffset PlanOnlineTime { get;  set; }
    
    /// <summary>
    /// 产品经理
    /// </summary>
    public List<string> ProductManagers{ get;  set; } 
}