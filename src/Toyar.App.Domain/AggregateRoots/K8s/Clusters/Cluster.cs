namespace Toyar.App.Domain.AggregateRoots.K8s.Clusters;

public class Cluster : FullAggregateRoot
{
    public Cluster(string name, string config, string clusterVersion)
    {
        Name = name;
        Config = config;
        ClusterVersion = clusterVersion;
    }

    /// <summary>
    /// 集群名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 集群名称
    /// </summary>
    public string Config { get; private set; }

    /// <summary>
    /// 集群版本
    /// </summary>
    public string ClusterVersion { get; private set; }


    public Cluster SetName(string name)
    {
        Name = name;
        return this;
    }

    public Cluster SetConfig(string config)
    {
        Config = config;
        return this;
    }
    public Cluster SetClusterVersion(string clusterVersion)
    {
        ClusterVersion = clusterVersion;
        return this;
    }
}