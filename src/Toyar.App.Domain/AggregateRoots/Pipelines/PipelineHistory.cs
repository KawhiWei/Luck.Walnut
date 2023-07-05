using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.Pipelines;

public class PipelineHistory : FullEntity
{
    public PipelineHistory(string pipelineId, PipelineBuildStateEnum pipelineBuildState, ICollection<Stage>? pipelineScript, uint jenkinsBuildNumber, string imageVersion)
    {
        PipelineId = pipelineId;
        PipelineBuildState = pipelineBuildState;
        PipelineScript = pipelineScript;
        JenkinsBuildNumber = jenkinsBuildNumber;
        ImageVersion = imageVersion;
    }

    /// <summary>
    /// 流水线Id
    /// </summary>
    public string PipelineId { get; private set; }

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum PipelineBuildState { get; private set; }

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage>? PipelineScript { get; private set; }

    /// <summary>
    /// Jenkins执行Build的编号
    /// </summary>
    public uint JenkinsBuildNumber { get; private set; }

    /// <summary>
    /// 镜像版本号
    /// </summary>
    public string ImageVersion { get; private set; }


    /// <summary>
    /// 设置流水线状态
    /// </summary>
    /// <param name="pipelineBuildState"></param>
    /// <returns></returns>
    public PipelineHistory SetPipelineBuildState(PipelineBuildStateEnum pipelineBuildState)
    {
        PipelineBuildState = pipelineBuildState;
        return this;
    }
}