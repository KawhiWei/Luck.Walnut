using System.ComponentModel;

namespace Toyar.App.Domain.Shared.Enums;

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
    /// 
    /// </summary>
    [Description("编译发布")]
    CompilePublish=2,
    
    /// <summary>
    /// 构建Docker镜像
    /// </summary>
    [Description("构建Docker镜像")]
    BuildDockerImage=3,
    
    /// <summary>
    /// 执行命令
    /// </summary>
    [Description("执行命令")]
    ExecuteCommand=4,

    /// <summary>
    /// 部署
    /// </summary>
    [Description("部署")]
    Deploy = 4,

}