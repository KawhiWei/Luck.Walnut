namespace Toyar.App.Dto.K8s.Clusters
{
    public class ClusterBaseDto
    {

        /// <summary>
        /// 集群名称
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// 集群名称
        /// </summary>
        public string Config { get; set; } = default!;

        /// <summary>
        /// 集群版本
        /// </summary>
        public string ClusterVersion { get; set; } = default!;
    }


}
