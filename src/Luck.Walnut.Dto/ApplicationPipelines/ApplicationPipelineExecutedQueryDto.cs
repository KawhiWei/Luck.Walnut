using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineExecutedQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum? PipelineBuildState { get;  set; }
}