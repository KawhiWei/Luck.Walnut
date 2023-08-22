namespace Toyar.App.Domain.AggregateRoots.WorkFlows;

public class WorkFlow : FullAggregateRoot
{
    public WorkFlow(string name)
    {
        Name = name;
    }

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 工作流Git配置
    /// </summary>
    public WorkFlowGitConfigValueObject? WorkFlowGitConfig { get; set; }

    /// <summary>
    /// CI流水线Id
    /// </summary>
    public string CiPipeLineId { get; private set; }
    
    /// <summary>
    /// 部署流水线Id
    /// </summary>
    public string WorkLoadId { get; private set; }
}