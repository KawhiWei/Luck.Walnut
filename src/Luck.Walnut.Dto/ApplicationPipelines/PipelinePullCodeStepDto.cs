namespace Luck.Walnut.Dto.ApplicationPipelines;

public class PipelinePullCodeStepDto
{
    /// <summary>
    /// git地址
    /// </summary>
    public string Git { get; set; } = default!;
    
    /// <summary>
    /// 分支
    /// </summary>
    public string Branch { get; set; }= default!;
}