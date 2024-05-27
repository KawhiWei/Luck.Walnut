using Toyar.Infrastructure;

namespace Toyar.Domain.AggregateRoots.ToyarApps;

public class ToyarApp : FullAggregateRoot
{
    public ToyarApp(string appId, string appName, string moduleGit, string appType, string ownedUser, 
        DeployTypeEnum deployType, string appDeployStatusType, string note, bool isUseDeployTemplate)
    {
        AppId = appId;
        AppName = appName;
        ModuleGit = moduleGit;
        AppType = appType;
        OwnedUser = ownedUser;
        DeployType = deployType;
        AppDeployStatusType = appDeployStatusType;
        Note = note;
        IsUseDeployTemplate = isUseDeployTemplate;
    }

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppName { get; private set; }

    /// <summary>
    /// 代码仓库Git地址
    /// </summary>
    public string ModuleGit { get; private set; }

    /// <summary>
    /// 应用类型
    /// </summary>
    public string AppType { get; private set; }

    /// <summary>
    /// 应用负责人
    /// </summary>
    public string OwnedUser { get; private set; }

    /// <summary>
    /// 应用部署类型
    /// </summary>
    public DeployTypeEnum DeployType { get; private set; }

    /// <summary>
    /// 应用部署状态类型
    /// </summary>
    public string AppDeployStatusType { get; private set; }

    /// <summary>
    /// 应用描述
    /// </summary>
    public string Note { get; private set; }

    /// <summary>
    /// 是否使用部署模板
    /// </summary>
    public bool IsUseDeployTemplate { get; private set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUserName { get; private set; } = ToyarDefaultConstants.DefaultUserName;

    /// <summary>
    /// 创建人Id
    /// </summary>
    public string CreateUserId { get; private set; } = ToyarDefaultConstants.DefaultUserId;

    /// <summary>
    /// 最后修改人
    /// </summary>
    public string LastModificationUserName { get; private set; } =ToyarDefaultConstants.DefaultUserName;

    /// <summary>
    /// 最后修改人Id
    /// </summary>
    public string LastModificationUserId { get; private set; } = ToyarDefaultConstants.DefaultUserId;

    public ICollection<ToyarAppUserRelation> ToyarAppUserRelations { get; private set; } =
        new List<ToyarAppUserRelation>();

    public ICollection<ToyarAppEnvironmentRelation> ToyarAppEnvironmentRelations { get; private set; } =
        new List<ToyarAppEnvironmentRelation>();
}