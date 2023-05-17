namespace Toyar.App.Domain.AggregateRoots.Pipelines;

/// <summary>
/// 
/// </summary>
public class Container
{
    public Container(string containerName, string imageName, string workingDir)
    {
        ContainerName = containerName;
        ImageName = imageName;
        WorkingDir = workingDir;
    }

    /// <summary>
    /// 容器名称
    /// </summary>
    public string ContainerName { get; private set; }

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string ImageName { get; private set; }

    /// <summary>
    /// 工作目录
    /// </summary>
    public string WorkingDir { get; private set; }

    /// <summary>
    /// 参数
    /// </summary>
    public string[] ArgsArr { get; private set; } = new List<string>().ToArray();

    /// <summary>
    /// 参数
    /// </summary>
    public string[] CommandArr { get; private set; } = new List<string>().ToArray();

    public Container SetCommandArr(string [] commandArr)
    {
        CommandArr = commandArr;
        return this;
    }
    
    public Container SetArgsArr(string [] argsArr)
    {
        ArgsArr = argsArr;
        return this;
    }
}