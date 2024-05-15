using Toyar.Infrastructure;

namespace Toyar.Domain.AggregateRoots.ToyarApps;

public class ToyarApp : FullAggregateRoot
{
    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; } = string.Empty;

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppName { get; private set; } = string.Empty;

    /// <summary>
    /// 代码仓库Git地址
    /// </summary>
    public string ModuleGit { get; private set; } = string.Empty;

    /// <summary>
    /// 应用类型
    /// </summary>
    public string AppType { get; private set; } = string.Empty;

    /// <summary>
    /// 应用负责人
    /// </summary>
    public string OwnedUser { get; private set; } = string.Empty;

    /// <summary>
    /// 应用部署类型
    /// </summary>
    public DeployTypeEnum DeployType { get; private set; } = DeployTypeEnum.Kubernetes;

    /// <summary>
    /// 应用部署状态类型
    /// </summary>
    public string AppDeployStatusType { get; private set; } = string.Empty;

    /// <summary>
    /// 应用描述
    /// </summary>
    public string Note { get; private set; } = string.Empty;

    /// <summary>
    /// 是否使用部署模板
    /// </summary>
    public bool IsUseDeployTemplate { get; private set; }

    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string CreateUserName { get; private set; } = string.Empty;

    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string CreateUserId { get; private set; } = string.Empty;

    /// <summary>
    /// 最后修改人
    /// </summary>
    public string LastModificationUserName { get; private set; } = string.Empty;

    /// <summary>
    /// 最后修改人Id
    /// </summary>
    public string LastModificationUserId { get; private set; } = string.Empty;
    
    public ICollection<ToyarAppUserRelation> ToyarAppUserRelations { get; private set; } =
        new List<ToyarAppUserRelation>();
    
    public ICollection<ToyarAppEnvironmentRelation> ToyarAppEnvironmentRelations { get; private set; } =
        new List<ToyarAppEnvironmentRelation>();

    
    

}