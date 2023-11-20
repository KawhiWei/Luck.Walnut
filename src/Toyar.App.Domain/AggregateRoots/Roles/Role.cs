namespace Toyar.App.Domain.AggregateRoots.Roles;

public class Role : FullAggregateRoot
{
    public Role(string name)
    {
        Name = name;
    }

    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; private set; }
    
    
    /// <summary>
    /// 创建人
    /// </summary>
    public string CreateUser { get; private set; } = default!;

    /// <summary>
    /// 最近修改人
    /// </summary>
    public string LastModificationUser { get; private set; } = default!;
}