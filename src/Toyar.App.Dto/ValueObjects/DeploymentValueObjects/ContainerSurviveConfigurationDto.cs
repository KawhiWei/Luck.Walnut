namespace Toyar.App.Dto.ValueObjects.DeploymentValueObjects;

public class ContainerSurviveConfigurationDto
{
    /// <summary>
    /// 
    /// </summary>
    public string Scheme { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Path { get; set; } = default!;

    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; set; } = default!;

    /// <summary>
    /// 端口
    /// </summary>
    public int InitialDelaySeconds { get; set; } = default!;

    /// <summary>
    /// 端口
    /// </summary>
    public int PeriodSeconds { get; set; } = default!;
}