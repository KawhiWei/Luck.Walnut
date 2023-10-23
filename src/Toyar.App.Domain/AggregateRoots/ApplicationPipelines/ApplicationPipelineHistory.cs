using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipelineHistory : FullEntity
{
    public ApplicationPipelineHistory(string pipelineId, PipelineBuildStateEnum pipelineBuildState, IEnumerable<Stage>? pipelineScript, uint jenkinsBuildNumber, string imageVersion, string appId)
    {
        PipelineId = pipelineId;
        PipelineBuildState = pipelineBuildState;
        PipelineScript = pipelineScript;
        JenkinsBuildNumber = jenkinsBuildNumber;
        ImageVersion = imageVersion;
        AppId = appId;
    }

    
    /// <summary>
    /// 流水线Id
    /// </summary>
    public string PipelineId { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; private set; }
    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum PipelineBuildState { get; private set; }

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public IEnumerable<Stage> PipelineScript { get; private set; }

    /// <summary>
    /// Jenkins执行Build的编号
    /// </summary>
    public uint JenkinsBuildNumber { get; private set; }

    /// <summary>
    /// 镜像版本号
    /// </summary>
    public string ImageVersion { get; private set; }
    
    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get; private set; } = default!;
        
    /// <summary>
    /// 最近修改人
    /// </summary>
    public string LastModificationUser { get; private set; } = default!;

    /// <summary>
    /// 设置流水线状态
    /// </summary>
    /// <param name="pipelineBuildState"></param>
    /// <returns></returns>
    public ApplicationPipelineHistory SetPipelineBuildState(PipelineBuildStateEnum pipelineBuildState)
    {
        PipelineBuildState = pipelineBuildState;
        return this;
    }
}