using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Assignments;

/// <summary>
/// 任务
/// </summary>
public class Assignment : FullAggregateRoot
{
    public Assignment(string name, DateOnly planStartTime, DateOnly planEndTime, double estimatedWorkingHours, ComplexityEnum complexity, string handlerPeople, string describe, AssignmentTypeEnum assignmentType, DateOnly? planProposeTime)
    {
        Name = name;
        PlanStartTime = planStartTime;
        PlanEndTime = planEndTime;
        EstimatedWorkingHours = estimatedWorkingHours;
        Complexity = complexity;
        HandlerPeople = handlerPeople;
        Describe = describe;
        AssignmentType = assignmentType;
        PlanProposeTime = planProposeTime;
    }

    /// <summary>
    /// 任务名称
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// 任务类型
    /// </summary>
    public AssignmentTypeEnum AssignmentType { get; private set; }

    
    /// <summary>
    /// 计划开始时间
    /// </summary>
    public DateOnly PlanStartTime { get; private set; } = default!;
    
    /// <summary>
    /// 计划结束时间
    /// </summary>
    public DateOnly PlanEndTime { get; private set; } = default!;
    
    /// <summary>
    /// 预估工时
    /// </summary>
    public double EstimatedWorkingHours { get; private set; } = default!;
    
    /// <summary>
    /// 复杂度
    /// </summary>
    public ComplexityEnum Complexity { get; private set; } = default!;
    
    /// <summary>
    /// 计划提测时间
    /// </summary>
    public DateOnly? PlanProposeTime { get; private set; } = default!;
    
    /// <summary>
    /// 处理人
    /// </summary>
    public string HandlerPeople { get; private set; }

    /// <summary>
    /// 任务描述
    /// </summary>
    public string Describe { get; private set; }
    
    /// <summary>
    /// 事项Id可能为空
    /// </summary>
    public string? MetterId { get; private set; }=string.Empty;


    /// <summary>
    /// 写入事项Id
    /// </summary>
    /// <param name="metterId"></param>
    /// <returns></returns>
    public Assignment SetMetterId(string metterId)
    {
        MetterId = metterId;
        return this;
    }

}