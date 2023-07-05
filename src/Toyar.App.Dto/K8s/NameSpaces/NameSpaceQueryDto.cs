namespace Toyar.App.Dto.K8s.NameSpaces;

public class NameSpaceQueryDto : PageBaseInputDto
{
    /// <summary>
    /// 中文名称
    /// </summary>
    public string? ChineseName { get; set; }
    /// <summary>
    /// 明明空间名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 集群Id
    /// </summary>
    public string? ClusterId { get; set; }
}