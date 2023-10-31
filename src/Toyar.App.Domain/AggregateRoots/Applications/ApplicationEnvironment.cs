namespace Toyar.App.Domain.AggregateRoots.Applications;

public class ApplicationEnvironment : FullEntity
{
    public ApplicationEnvironment(string environmentId, string environmentName, string applicationId)
    {
        EnvironmentId = environmentId;
        EnvironmentName = environmentName;
        ApplicationId = applicationId;
    }

    /// <summary>
    /// 环境Id
    /// </summary>
    public string EnvironmentId { get; private set; }

    /// <summary>
    /// 环境名称
    /// </summary>
    public string EnvironmentName { get; private set; }

    /// <summary>
    /// 应用Id 
    /// </summary>
    public string ApplicationId { get; private set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get; private set; } = default!;

    /// <summary>
    /// 最近修改人
    /// </summary>
    public string LastModificationUser { get; private set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public Application Application { get; } = default!;
}