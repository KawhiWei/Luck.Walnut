using Luck.Framework.Extensions;

namespace Toyar.App.Dto.ApplicationPipelines;

public class ApplicationPipelineHistoryOutputDto:ApplicationPipelineHistoryBaseDto
{

    /// <summary>
    /// 流水线状态
    /// </summary>
    public string PipelineBuildStateName => PipelineBuildState.ToDescription();

    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset CreationTime { get; set; } = default!;
    
    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get;  set; } = default!;


}