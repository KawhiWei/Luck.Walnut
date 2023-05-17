namespace Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;

public class ContinuousIntegrationImageVersion : FullEntity
{
    public ContinuousIntegrationImageVersion(string continuousIntegrationImageId, string version)
    {
        ContinuousIntegrationImageId = continuousIntegrationImageId;
        Version = version;
    }

    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string ContinuousIntegrationImageId { get; private set; }

    /// <summary>
    /// 版本号
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public ContinuousIntegrationImage ContinuousIntegrationImage { get; } = default!;
}