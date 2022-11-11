using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineOutputDto:ApplicationPipelineBaseDto
{
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published  { get; set; }


    public string PipelineStateName => PipelineState.ToDescription();
}