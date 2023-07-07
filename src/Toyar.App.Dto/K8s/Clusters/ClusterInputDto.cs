namespace Toyar.App.Dto.K8s.Clusters
{
    public class ClusterInputDto : ClusterBaseDto
    {

    }

    public class ClusterOutputDto : ClusterBaseDto
    {

        public string Id { get; set; } = default!;
    }

    public class ClusterQueryDto : PageBaseInputDto
    {
        /// <summary>
        /// 集群名称
        /// </summary>
        public string? Name { get; set; }
    }



}
