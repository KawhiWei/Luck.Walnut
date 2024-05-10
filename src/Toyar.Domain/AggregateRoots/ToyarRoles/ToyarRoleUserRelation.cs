namespace Toyar.Domain.AggregateRoots.ToyarRoles;

public class ToyarRoleUserRelation : FullEntity
{
    /// <summary>
    /// 角色主键Id
    /// </summary>
    public string RoleId { get; private set; } = string.Empty;

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