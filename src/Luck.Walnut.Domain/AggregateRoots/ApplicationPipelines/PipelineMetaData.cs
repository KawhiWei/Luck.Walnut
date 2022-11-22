using System.Web;

namespace Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;

public class PipelineMetaData
{
    public PipelineMetaData(List<Container> containers, List<Stage> stages)
    {
        Containers = containers;
        Stages = stages;
    }

    /// <summary>
    /// 基础容器数组
    /// </summary>
    public List<Container> Containers { get; private set; }

    /// <summary>
    /// 流水线数据
    /// </summary>
    public List<Stage> Stages { get; private set; }
}

public class CodeData
{
    private string _sourceCode;

    /// <summary>
    /// 获取或设置 源代码字符串
    /// </summary>
    public string SourceCode
    {
        get => _sourceCode;
        set => _sourceCode = HttpUtility.HtmlDecode(value);
    }
}