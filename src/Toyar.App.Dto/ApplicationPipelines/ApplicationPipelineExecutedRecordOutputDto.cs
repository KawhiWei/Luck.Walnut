using Luck.Framework.Extensions;

namespace Toyar.App.Dto.ApplicationPipelines;

public class ApplicationPipelineExecutedRecordOutputDto:ApplicationPipelineExecutedBaseDto
{

    /// <summary>
    /// 流水线状态
    /// </summary>
    public string PipelineBuildStateName => PipelineBuildState.ToDescription();



}