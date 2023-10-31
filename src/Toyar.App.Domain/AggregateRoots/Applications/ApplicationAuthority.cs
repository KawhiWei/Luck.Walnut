namespace Toyar.App.Domain.AggregateRoots.Applications;

/// <summary>
/// 应用权限
/// </summary>
public class ApplicationAuthority : FullEntity
{
    public ApplicationAuthority(string userId, string userName, string applicationId)
    {
        UserId = userId;
        UserName = userName;
        ApplicationId = applicationId;
    }

    /// <summary>
    /// 用户Id
    /// </summary>
    public string UserId { get; private set; }

    /// <summary>
    /// 用户名称
    /// </summary>
    public string UserName { get; private set; }
    
    /// <summary>
    /// 环境Id
    /// </summary>
    public string EnvironmentId { get; private set; }

    /// <summary>
    /// 应用Id 
    /// </summary>
    public string ApplicationId { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public Application Application { get; } = default!;

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get; private set; } = default!;

    /// <summary>
    /// 最近修改人
    /// </summary>
    public string LastModificationUser { get; private set; } = default!;
}