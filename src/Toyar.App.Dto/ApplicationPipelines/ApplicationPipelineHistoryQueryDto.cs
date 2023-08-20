using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.ApplicationPipelines;

public class ApplicationPipelineHistoryQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum? PipelineBuildState { get;  set; }
}