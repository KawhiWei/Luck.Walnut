using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class StepDto
{
    /// <summary>
    /// 步骤名称
    /// </summary>
    public string Name { get;  set; }= default!;
    
    /// <summary>
    /// 步骤类型
    /// </summary>
    public StepTypeEnum StepType { get;  set; }
    
    /// <summary>
    /// 执行内容
    /// </summary>
    public string Content { get;  set; }= default!;
}