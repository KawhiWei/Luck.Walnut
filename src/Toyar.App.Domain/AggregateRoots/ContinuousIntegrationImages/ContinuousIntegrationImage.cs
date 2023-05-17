namespace Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;

/// <summary>
/// CI持續集成Runner鏡像
/// </summary>
public class ContinuousIntegrationImage : FullAggregateRoot
{
    public ContinuousIntegrationImage(string name, string registryUrl)
    {
        Name = name;
        RegistryUrl = registryUrl;
    }

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// 镜像地址
    /// </summary>
    public string RegistryUrl { get; private set; }

    /// <summary>
    /// 配置项
    /// </summary>
    public ICollection<ContinuousIntegrationImageVersion> ContinuousIntegrationImageVersions { get; private set; } = new HashSet<ContinuousIntegrationImageVersion>();


    public ContinuousIntegrationImage AddBuildImageVersion(string version)
    {
        ContinuousIntegrationImageVersions.Add(new ContinuousIntegrationImageVersion(this.Id, version));
        return this;
    }

    public ContinuousIntegrationImage UpdateInfo(string name, string registryUrl)
    {
        Name = name;
        RegistryUrl = registryUrl;

        return this;
    }
}