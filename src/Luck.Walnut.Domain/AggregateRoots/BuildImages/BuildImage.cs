namespace Luck.Walnut.Domain.AggregateRoots.BuildImages;

public class BuildImage : FullAggregateRoot
{
    public BuildImage(string name, string buildImageName, string compileScript)
    {
        Name = name;
        BuildImageName = buildImageName;
        CompileScript = compileScript;
    }

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 镜像地址
    /// </summary>
    public string BuildImageName { get; private set; }
    
    /// <summary>
    /// 镜像地址
    /// </summary>
    public string CompileScript { get; private set; }

    /// <summary>
    /// 配置项
    /// </summary>
    public ICollection<BuildImageVersion> RunImageVersions { get; private set; } = new HashSet<BuildImageVersion>();


    public BuildImage AddRunImageVersion(string version)
    {
        RunImageVersions.Add(new BuildImageVersion(this.Id, version));
        return this;
    }

    public BuildImage UpdateInfo(string name, string buildImageName, string compileScript)
    {
        Name = name;
        BuildImageName = buildImageName;
        CompileScript = compileScript;

        return this;
    }
}