namespace Toyar.Domain.AggregateRoots.ToyarApps;

public class ToyarAppUserRelation : FullEntity
{
    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; } = string.Empty;
    
    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; private set; } = string.Empty;
    
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