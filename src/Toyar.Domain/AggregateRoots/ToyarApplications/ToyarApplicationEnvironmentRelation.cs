namespace Toyar.Domain.AggregateRoots.ToyarApplications;

public class ToyarApplicationEnvironmentRelation : FullEntity
{
    public ToyarApplicationEnvironmentRelation(string appId, string environmentId, string toyarApplicationId)
    {
        AppId = appId;
        EnvironmentId = environmentId;
        ToyarApplicationId = toyarApplicationId;
    }
    
    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 环境Id
    /// </summary>
    public string EnvironmentId { get; private set; }
    
    /// <summary>
    /// 应用主键唯一标识
    /// </summary>
    public string ToyarApplicationId { get; private set; }

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