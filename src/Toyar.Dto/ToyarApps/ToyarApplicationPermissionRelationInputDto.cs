namespace Toyar.Dto.ToyarApps;

public class ToyarApplicationPermissionRelationInputDto
{
    /// <summary>
    /// 用户id
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// 环境id
    /// </summary>
    public string EnvironmentId { get; set; } = string.Empty;

    /// <summary>
    /// 角色id
    /// </summary>
    public string RoleId { get; set; } = string.Empty;
}

public class ToyarApplicationEnvironmentRelationInputDto
{
    /// <summary>
    /// 环境id
    /// </summary>
    public List<string> EnvironmentIdList { get; set; } = new();
}