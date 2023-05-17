namespace Toyar.App.Dto.ContinuousIntegrationImages;

public class ContinuousIntegrationImageVersionOutputDto
{
    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string BuildImageId { get; set; } = default!;

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string Version { get;  set; } = default!;
    
}