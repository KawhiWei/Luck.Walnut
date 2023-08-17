using System.Web;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Domain.AggregateRoots.ApplicationPipelines;

public class PipelineMetaData
{
    public PipelineMetaData(List<Container> containers, List<Stage> stages, string pipelineScript, string webHookUrl)
    {
        Containers = containers;
        Stages = stages;
        PipelineScript = pipelineScript;
        WebHookUrl = webHookUrl;
    }

    /// <summary>
    /// 基础容器数组
    /// </summary>
    public List<Container> Containers { get; private set; }

    /// <summary>
    /// 流水线数据
    /// </summary>
    public List<Stage> Stages { get; private set; }
    /// <summary>
    /// 流水线数据
    /// </summary>
    public string PipelineScript { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string WebHookUrl { get; private set; }
}
