namespace Toyar.App.Domain.AggregateRoots.Authorities;

/// <summary>
/// 应用权限关联关系
/// </summary>
public class Authority : FullAggregateRoot
{
    public Authority(string userId, string userName, string applicationId, string? environmentId,string? roleId)
    {
        UserId = userId;
        UserName = userName;
        ApplicationId = applicationId;
        EnvironmentId = environmentId;
        RoleId = roleId;
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
    /// 应用Id 
    /// </summary>
    public string ApplicationId { get; private set; }

    /// <summary>
    /// 环境Id
    /// </summary>
    public string? EnvironmentId { get; private set; }
    
    /// <summary>
    /// 角色Id
    /// </summary>
    public string? RoleId { get; private set;  }

    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get; private set; } = default!;

    /// <summary>
    /// 最近修改人
    /// </summary>
    public string LastModificationUser { get; private set; } = default!;
    
}