using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipelineExecutedRecord : FullEntity
{
    public ApplicationPipelineExecutedRecord(string applicationPipelineId, PipelineBuildStateEnum pipelineBuildState, ICollection<Stage> pipelineScript, uint jenkinsBuildNumber)
    {
        ApplicationPipelineId = applicationPipelineId;
        PipelineBuildState = pipelineBuildState;
        PipelineScript = pipelineScript;
        JenkinsBuildNumber = jenkinsBuildNumber;
    }

    /// <summary>
    /// 
    /// </summary>
    public string ApplicationPipelineId { get; private set; }

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum PipelineBuildState { get; private set; }

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage> PipelineScript { get; private set; }

    /// <summary>
    /// Jenkins执行Build的编号
    /// </summary>
    public uint JenkinsBuildNumber { get; private set; }

    /// <summary>
    /// 设置流水线状态
    /// </summary>
    /// <param name="pipelineBuildState"></param>
    /// <returns></returns>
    public ApplicationPipelineExecutedRecord SetPipelineBuildState(PipelineBuildStateEnum pipelineBuildState)
    {
        PipelineBuildState = pipelineBuildState;
        return this;
    }
}