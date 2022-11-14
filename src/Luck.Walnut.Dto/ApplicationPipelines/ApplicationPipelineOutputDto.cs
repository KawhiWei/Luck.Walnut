using Luck.Framework.Extensions;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineOutputDto:ApplicationPipelineBaseDto
{
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published  { get; set; }

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum PipelineBuildState { get; set; } = PipelineBuildStateEnum.Running;
    
    /// <summary>
    /// 流水线状态
    /// </summary>
    public uint JenkinsBuildNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string LastApplicationPipelineExecutedRecordId { get; set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public string PipelineBuildStateName => PipelineBuildState.ToDescription();
}