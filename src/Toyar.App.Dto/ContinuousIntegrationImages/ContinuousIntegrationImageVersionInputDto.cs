namespace Toyar.App.Dto.ContinuousIntegrationImages;

/// <summary>
/// 镜像版本inputDto
/// </summary>
public class ContinuousIntegrationImageVersionInputDto
{
    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string BuildImageId { get; set; } = default!;

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string Version { get; set; } = default!;
}
