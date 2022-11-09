using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineBaseDto
{
    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get;  set; }= default!;

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get;  set; }= default!;

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineStateEnum PipelineState { get;  set; }

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<StageDto> PipelineScript { get;  set; }= default!;

    /// <summary>
    /// 下一流水线Id
    /// </summary>
    public string? NextPipelineId { get;  set; }
    
}