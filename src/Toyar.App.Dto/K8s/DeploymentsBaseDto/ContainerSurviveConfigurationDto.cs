namespace Toyar.App.Dto.K8s.DeploymentsBaseDto;

public class ContainerSurviveConfigurationDto
{
    /// <summary>
    /// 
    /// </summary>
    public string? Scheme { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public int? Port { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public int? InitialDelaySeconds { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public int? PeriodSeconds { get; set; }
}