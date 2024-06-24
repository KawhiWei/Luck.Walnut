using Luck.Framework.Extensions;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Dto.ToyarApplicationDto;
using Toyar.Infrastructure;

namespace Toyar.Domain.AggregateRoots.ToyarApplications;

public class ToyarApplication : FullAggregateRoot
{
    public ToyarApplication(string appId, string appName, string moduleGit, string appType, string ownedUser,
        DeployTypeEnum instanceType, string appDeployStatusType, string note, bool isUseDeployTemplate)
    {
        AppId = appId;
        AppName = appName;
        ModuleGit = moduleGit;
        AppType = appType;
        OwnedUser = ownedUser;
        InstanceType = instanceType;
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
    public DeployTypeEnum InstanceType { get; private set; }

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
    public string LastModificationUserName { get; private set; } = ToyarDefaultConstants.DefaultUserName;

    /// <summary>
    /// 最后修改人Id
    /// </summary>
    public string LastModificationUserId { get; private set; } = ToyarDefaultConstants.DefaultUserId;

    public ICollection<ToyarApplicationPermissionRelation> ToyarApplicationPermissionRelations { get; private set; } =
        new List<ToyarApplicationPermissionRelation>();

    public ICollection<ToyarApplicationEnvironmentRelation> ToyarApplicationEnvironmentRelations { get; private set; } =
        new List<ToyarApplicationEnvironmentRelation>();

    public ICollection<ToyarApplicationDeploymentConfiguration> ToyarApplicationDeploymentConfigurations
    { get; private set; } = new List<ToyarApplicationDeploymentConfiguration>();

    
    public void AddToyarAppPermissionRelation(string userId, string environmentId, string roleId)
    {
        ToyarApplicationPermissionRelations.Add(new ToyarApplicationPermissionRelation(AppId, userId, environmentId, roleId));
    }

    public void DeleteToyarAppPermissionRelation(string permissionId)
    {
        ToyarApplicationPermissionRelations.Remove(item => item.Id == permissionId);
    }
    
    
    public void AddToyarAppEnvironmentRelation(string environmentId)
    {
        ToyarApplicationEnvironmentRelations.Add(new ToyarApplicationEnvironmentRelation(AppId, environmentId));
    }
    
    public void AddToyarApplicationDeploymentConfiguration(string environmentId, string healthCheckMode,
        string healthCheckUrl, string releaseStrategy, List<string> servicePort, string botNotificationType,
        string botNotificationUrl, string deploymentBeforeWebHookUrl, string deploymentAfterWebHookUrl, 
        string memorySizeMaxMib, bool isDefaultDeployment)
    {
        ToyarApplicationDeploymentConfigurations.Add(new ToyarApplicationDeploymentConfiguration(AppId, environmentId,
            healthCheckMode, healthCheckUrl,
            releaseStrategy, servicePort, botNotificationType, botNotificationUrl, deploymentBeforeWebHookUrl,
            deploymentAfterWebHookUrl, memorySizeMaxMib, isDefaultDeployment));
    }
    
}