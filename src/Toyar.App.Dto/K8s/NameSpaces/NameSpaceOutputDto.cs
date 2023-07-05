namespace Toyar.App.Dto.K8s.NameSpaces;

public class NameSpaceOutputDto : NameSpaceBaseDto
{
    /// <summary>
    /// 归属集群
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// 归属集群
    /// </summary>
    public string ClusterName { get; set; } = default!;
}