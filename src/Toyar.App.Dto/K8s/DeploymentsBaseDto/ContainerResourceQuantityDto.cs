namespace Toyar.App.Dto.K8s.DeploymentsBaseDto;

/// <summary>
/// 资源配置
/// </summary>
public class ContainerResourceQuantityDto
{
    /// <summary>
    /// 
    /// </summary>
    public string? Cpu { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Memory { get; set; }
}