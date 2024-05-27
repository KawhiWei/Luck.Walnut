using Toyar.Infrastructure;

namespace Toyar.Dto.ToyarApps;

public abstract class ToyarAppBaseDto
{
    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get;  set; } = string.Empty;

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppName { get;  set; } = string.Empty;

    /// <summary>
    /// 代码仓库Git地址
    /// </summary>
    public string ModuleGit { get;  set; } = string.Empty;

    /// <summary>
    /// 应用类型
    /// </summary>
    public string AppType { get;  set; } = string.Empty;

    /// <summary>
    /// 应用负责人
    /// </summary>
    public string OwnedUser { get;  set; } = string.Empty;

    /// <summary>
    /// 应用部署类型
    /// </summary>
    public DeployTypeEnum DeployType { get;  set; } = DeployTypeEnum.Kubernetes;

    /// <summary>
    /// 应用部署状态类型
    /// </summary>
    public string AppDeployStatusType { get;  set; } = string.Empty;

    /// <summary>
    /// 应用描述
    /// </summary>
    public string Note { get;  set; } = string.Empty;

    /// <summary>
    /// 是否使用部署模板
    /// </summary>
    public bool IsUseDeployTemplate { get;  set; }
}