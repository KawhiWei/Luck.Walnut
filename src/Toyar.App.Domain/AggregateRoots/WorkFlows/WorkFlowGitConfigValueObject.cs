namespace Toyar.App.Domain.AggregateRoots.WorkFlows;

/// <summary>
/// 工作流Git配置
/// </summary>
public class WorkFlowGitConfigValueObject
{
    public WorkFlowGitConfigValueObject(string targetBranch, string label)
    {
        TargetBranch = targetBranch;
        Label = label;
    }

    /// <summary>
    /// 目标分支
    /// </summary>
    public string TargetBranch { get; private set; }
    
    /// <summary>
    /// 名称
    /// </summary>
    public string Label { get; private set; }
}