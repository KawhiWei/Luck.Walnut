namespace Luck.Walnut.Dto.BuildImages;

public class BuildImageVersionOutputDto
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