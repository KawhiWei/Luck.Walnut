namespace Toyar.Dto.ToyarApplications;

public class ToyarApplicationDeploymentConfigurationInputDto
{
    public string EnvironmentId { get; set; } = string.Empty;

    /// <summary>
    /// 健康检查方式
    /// </summary>
    public string HealthCheckMode { get; set; } = string.Empty;

    /// <summary>
    /// 健康检查url
    /// </summary>
    public string HealthCheckUrl { get; set; } = string.Empty;

    /// <summary>
    /// 发布模式
    /// </summary>
    public string ReleaseStrategy { get; private set; } = string.Empty;

    /// <summary>
    /// 服务端口
    /// </summary>
    public List<string> ServicePort { get; private set; } = new();

    /// <summary>
    /// 发布通知类型：（企业微信、钉钉、飞书等）
    /// </summary>
    public string BotNotificationType { get; private set; } = string.Empty;

    /// <summary>
    /// 发布通知Url
    /// </summary>
    public string BotNotificationUrl { get; private set; } = string.Empty;

    /// <summary>
    /// 部署前回调地址
    /// </summary>
    public string DeploymentBeforeWebHookUrl { get; private set; } = string.Empty;

    /// <summary>
    /// 部署后回调地址
    /// </summary>
    public string DeploymentAfterWebHookUrl { get; private set; } = string.Empty;

    /// <summary>
    /// 重启策略
    /// </summary>
    public string RestartPolicy { get; private set; } = "always";

    /// <summary>
    /// 最大内存
    /// </summary>
    public string MemorySizeMaxMib { get; private set; } = string.Empty;


    /// <summary>
    /// 最大内存
    /// </summary>
    public string Cpu { get; private set; } = string.Empty;

    /// <summary>
    /// 容器模式
    /// </summary>
    public string ContainerPattern { get; private set; } = string.Empty;

    /// <summary>
    /// 环境变量
    /// </summary>
    public Dictionary<string, string> EnvironmentVariable { get; set; } = new();

    /// <summary>
    /// 挂载目录
    /// </summary>
    public Dictionary<string, string> Mounts { get; set; } = new();
}