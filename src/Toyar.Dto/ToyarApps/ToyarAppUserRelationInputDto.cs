namespace Toyar.Dto.ToyarApps;

public class ToyarAppUserRelationInputDto
{

    /// <summary>
    /// 应用标识
    /// </summary>
    public string AppId { get; set; } = string.Empty;
    
    /// <summary>
    /// 用户id
    /// </summary>
    public List<string> UserIdList { get; set; } = new();
}