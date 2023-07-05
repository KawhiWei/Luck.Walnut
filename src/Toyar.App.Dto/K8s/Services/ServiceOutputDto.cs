namespace Toyar.App.Dto.K8s.Services;

public class ServiceOutputDto : ServiceBaseDto
{

    /// <summary>
    /// 归属集群
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// 命名空间
    /// </summary>
    public string NameSpaceName { get; set; } = default!;

    /// <summary>
    /// 命名空间
    /// </summary>
    public string NameSpaceChineseName { get; set; } = default!;

    /// <summary>
    /// 集群名称
    /// </summary>
    public string ClusterName { get; set; } = default!;


    /// <summary>
    /// 是否发布
    /// </summary>
    public bool IsPublish { get; set; }



}