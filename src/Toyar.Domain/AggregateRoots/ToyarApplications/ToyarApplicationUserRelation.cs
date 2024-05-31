namespace Toyar.Domain.AggregateRoots.ToyarApplications;

public class ToyarApplicationUserRelation : FullEntity
{
    public ToyarApplicationUserRelation(string appId, string userId)
    {
        AppId = appId;
        UserId = userId;
    }

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; }
    
    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; private set; }
    
    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string CreateUserName { get; private set; } = string.Empty;

    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string CreateUserId { get; private set; } = string.Empty;

    /// <summary>
    /// 最后修改人
    /// </summary>
    public string LastModificationUserName { get; private set; } = string.Empty;

    /// <summary>
    /// 最后修改人Id
    /// </summary>
    public string LastModificationUserId { get; private set; } = string.Empty;
}