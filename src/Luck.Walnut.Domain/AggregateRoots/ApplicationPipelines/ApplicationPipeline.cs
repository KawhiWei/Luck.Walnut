using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipeline : FullAggregateRoot
{
    public ApplicationPipeline(string appId, string name, PipelineStatusEnum pipelineStatus, string nextPipelineId, string pipelineScript, string appEnvironmentId)
    {
        AppId = appId;
        Name = name;
        PipelineStatus = pipelineStatus;
        NextPipelineId = nextPipelineId;
        PipelineScript = pipelineScript;
        AppEnvironmentId = appEnvironmentId;
    }

    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get; private set; }

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineStatusEnum PipelineStatus { get; private set; }
    
    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public string PipelineScript { get; private set; }

    /// <summary>
    /// 下一流水线Id
    /// </summary>
    public string? NextPipelineId { get; private set; }
}