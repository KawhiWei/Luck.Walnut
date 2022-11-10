using System.ComponentModel;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 步骤类型
/// </summary>
public enum StepTypeEnum{

    /// <summary>
    /// 拉取代码
    /// </summary>
    [Description("拉取代码")]
    PullCode=1,
    
    /// <summary>
    /// 构建Docker镜像
    /// </summary>
    [Description("构建Docker镜像")]
    BuildDockerImage=2,
    
    /// <summary>
    /// 执行命令
    /// </summary>
    [Description("执行命令")]
    ExecuteCommand=3,
    
}