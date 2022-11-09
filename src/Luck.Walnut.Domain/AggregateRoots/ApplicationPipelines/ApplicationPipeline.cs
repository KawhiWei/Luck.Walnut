using System.Text.Json.Serialization;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipeline : FullAggregateRoot
{
    public ApplicationPipeline()
    {
    }


    public ApplicationPipeline(string appId, string name, PipelineStateEnum pipelineState, IList<Stage> pipelineScript, string appEnvironmentId, bool published)
    {
        AppId = appId;
        Name = name;
        PipelineState = pipelineState;
        PipelineScript = pipelineScript;
        AppEnvironmentId = appEnvironmentId;
        Published = published;
    }

    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineStateEnum PipelineState { get; private set; }

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage> PipelineScript { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get; private set; }

    /// <summary>
    /// 下一流水线Id
    /// </summary>
    public string? NextPipelineId { get; private set; } = default!;

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="pipelineScript"></param>
    /// <returns></returns>
    public ApplicationPipeline SetPipelineScript(ICollection<Stage> pipelineScript)
    {
        PipelineScript = pipelineScript;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="published"></param>
    /// <returns></returns>
    public ApplicationPipeline SetPublished(bool published)
    {
        Published = published;
        return this;
    }
}