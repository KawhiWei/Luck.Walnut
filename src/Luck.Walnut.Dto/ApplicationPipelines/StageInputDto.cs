namespace Luck.Walnut.Dto.ApplicationPipelines;

/// <summary>
/// 
/// </summary>
public class StageInputDto
{
    /// <summary>
    /// 阶段
    /// </summary>
    public string Name { get;  set; }= default!;
    
    /// <summary>
    /// 步骤
    /// </summary>
    public List<StepInputDto> Steps{get;  set;}= default!;
}