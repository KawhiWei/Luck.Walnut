using Toyar.Infrastructure;

namespace Toyar.Domain.AggregateRoots.ToyarApplications;

public class ToyarApplicationDeploymentConfiguration : FullEntity
{
    public ToyarApplicationDeploymentConfiguration(string appId, string environmentId, string healthCheckMode,
        string healthCheckUrl, string releaseStrategy, List<string> servicePort, string botNotificationType,
        string botNotificationUrl, string deploymentBeforeWebHookUrl, string deploymentAfterWebHookUrl,
        bool isDefaultDeployment)
    {
        AppId = appId;
        EnvironmentId = environmentId;
        HealthCheckMode = healthCheckMode;
        HealthCheckUrl = healthCheckUrl;
        ReleaseStrategy = releaseStrategy;
        ServicePort = servicePort;
        BotNotificationType = botNotificationType;
        BotNotificationUrl = botNotificationUrl;
        DeploymentBeforeWebHookUrl = deploymentBeforeWebHookUrl;
        DeploymentAfterWebHookUrl = deploymentAfterWebHookUrl;
        IsDefaultDeployment = isDefaultDeployment;
    }

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 环境标识
    /// </summary>
    public string EnvironmentId { get; private set; }

    /// <summary>
    /// 健康检查方式
    /// </summary>
    public string HealthCheckMode { get; private set; }

    /// <summary>
    /// 健康检查url
    /// </summary>
    public string HealthCheckUrl { get; private set; }

    /// <summary>
    /// 发布模式
    /// </summary>
    public string ReleaseStrategy { get; private set; }

    /// <summary>
    /// 服务端口
    /// </summary>
    public List<string> ServicePort { get; private set; }

    /// <summary>
    /// 发布通知类型：（企业微信、钉钉、飞书等）
    /// </summary>
    public string BotNotificationType { get; private set; }

    /// <summary>
    /// 发布通知Url
    /// </summary>
    public string BotNotificationUrl { get; private set; }

    /// <summary>
    /// 部署前回调地址
    /// </summary>
    public string DeploymentBeforeWebHookUrl { get; private set; }

    /// <summary>
    /// 部署后回调地址
    /// </summary>
    public string DeploymentAfterWebHookUrl { get; private set; }

    /// <summary>
    /// 重启策略
    /// </summary>
    public string RestartPolicy { get; private set; } = "always";

    /// <summary>
    /// 最大内存
    /// </summary>
    public string MemorySizeMaxMib { get; private set; }

    /// <summary>
    /// 是否默认部署配置
    /// </summary>
    public bool IsDefaultDeployment { get; private set; }

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
}