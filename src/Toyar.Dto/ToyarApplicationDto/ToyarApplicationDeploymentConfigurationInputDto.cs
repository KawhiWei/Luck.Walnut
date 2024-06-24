namespace Toyar.Dto.ToyarApplicationDto;

public class ToyarApplicationDeploymentConfigurationInputDto
{

    /// <summary>
    /// 环境标识
    /// </summary>
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
    public string ReleaseStrategy { get; set; } = string.Empty;

    /// <summary>
    /// 服务端口
    /// </summary>
    public List<string> ServicePort { get; set; } = new();

    /// <summary>
    /// 发布通知类型：（企业微信、钉钉、飞书等）
    /// </summary>
    public string BotNotificationType { get; set; } = string.Empty;

    /// <summary>
    /// 发布通知Url
    /// </summary>
    public string BotNotificationUrl { get; set; } = string.Empty;

    /// <summary>
    /// 部署前回调地址
    /// </summary>
    public string DeploymentBeforeWebHookUrl { get; set; } = string.Empty;

    /// <summary>
    /// 部署后回调地址
    /// </summary>
    public string DeploymentAfterWebHookUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// 最大内存
    /// </summary>
    public string MemorySizeMaxMib { get;  set; }= string.Empty;
}