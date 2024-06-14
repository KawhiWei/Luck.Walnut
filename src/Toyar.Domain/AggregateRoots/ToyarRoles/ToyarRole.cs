namespace Toyar.Domain.AggregateRoots.ToyarRoles;

public class ToyarRole : FullAggregateRoot
{
    /// <summary>
    /// 英文名称
    /// </summary>
    public string EnglishName { get; private set; } = string.Empty;

    /// <summary>
    /// 中文名称
    /// </summary>
    public string ChinesName { get; private set; } = string.Empty;
    
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