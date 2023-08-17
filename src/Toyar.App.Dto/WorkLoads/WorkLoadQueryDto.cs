namespace Toyar.App.Dto.WorkLoads;

public class WorkLoadQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 命名空间Id
    /// </summary>
    public string? NameSpaceId { get; set; }

    /// <summary>
    /// 中文名称
    /// </summary>
    public string? ChineseName { get; set; }


    /// <summary>
    /// 部署环境
    /// </summary>
    public string? EnvironmentName { get; set; }
}
