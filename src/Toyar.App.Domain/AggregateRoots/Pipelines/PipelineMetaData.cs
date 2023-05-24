using System.Web;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Domain.AggregateRoots.Pipelines;

public class PipelineMetaData
{
    public PipelineMetaData(List<Container> containers, List<Stage> stages, string pipelineScript)
    {
        Containers = containers;
        Stages = stages;
        PipelineScript = pipelineScript;
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
}
