namespace Toyar.App.Dto.ApplicationPipelines;

/// <summary>
/// 
/// </summary>
public class StageDto
{
    /// <summary>
    /// 阶段
    /// </summary>
    public string Name { get;  set; }= default!;
    
    /// <summary>
    /// 步骤
    /// </summary>
    public List<StepDto> Steps{get;  set;}= default!;
}