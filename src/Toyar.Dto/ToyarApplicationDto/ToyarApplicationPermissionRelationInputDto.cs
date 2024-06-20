namespace Toyar.Dto.ToyarApplicationDto;

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