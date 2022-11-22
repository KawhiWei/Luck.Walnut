using System.Text.Json.Serialization;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class ApplicationPipeline : FullAggregateRoot
{
    public ApplicationPipeline()
    {
    }


    public ApplicationPipeline(string appId, string name, IList<Stage> pipelineScript, string appEnvironmentId, bool published, string componentIntegrationId)
    {
        AppId = appId;
        Name = name;
        PipelineScript = pipelineScript;
        AppEnvironmentId = appEnvironmentId;
        Published = published;
        ComponentIntegrationId = componentIntegrationId;
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
    /// 流水线Dsl
    /// </summary>
    public ICollection<Stage> PipelineScript { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get; private set; }

    /// <summary>
    /// Jenkins下一次Build的Id
    /// </summary>
    public uint NextBuildNumber { get; private set; } = default!;

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool Published { get; private set; }

    /// <summary>
    /// 组件集成Id
    /// </summary>
    public string ComponentIntegrationId { get; private set; }

    /// <summary>
    /// 执行记录
    /// </summary>
    public ICollection<ApplicationPipelineExecutedRecord> ApplicationPipelineExecutedRecords { get; private set; } = new HashSet<ApplicationPipelineExecutedRecord>();

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
    /// <param name="componentIntegrationId"></param>
    /// <returns></returns>
    public ApplicationPipeline SetComponentIntegrationId(string componentIntegrationId)
    {
        ComponentIntegrationId = componentIntegrationId;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextBuildNumber"></param>
    /// <returns></returns>
    public ApplicationPipeline AddApplicationPipelineExecutedRecord(uint nextBuildNumber)
    {
        var applicationPipelineExecutedRecord = new ApplicationPipelineExecutedRecord(this.Id, PipelineBuildStateEnum.Running, this.PipelineScript, nextBuildNumber, $"{AppId}-{DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss")}-{nextBuildNumber}", null);
        ApplicationPipelineExecutedRecords.Add(applicationPipelineExecutedRecord);
        return this;
    }
}