namespace Luck.Walnut.Domain.AggregateRoots.BuildImages;

public class BuildImageVersion : FullEntity
{
    public BuildImageVersion(string buildImageId, string version)
    {
        BuildImageId = buildImageId;
        Version = version;
    }

    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string BuildImageId { get; private set; }

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public BuildImage BuildImage { get; } = default!;
}