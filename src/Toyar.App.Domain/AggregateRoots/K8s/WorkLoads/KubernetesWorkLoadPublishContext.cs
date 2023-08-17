using Toyar.App.Domain.AggregateRoots.WorkLoads;

namespace Toyar.App.Domain.AggregateRoots.K8s.WorkLoads
{
    /// <summary>
    /// 部署到K8s传输上下文
    /// </summary>
    public class KubernetesWorkLoadPublishContext : KubernetesPublishBaseContext
    {
        public KubernetesWorkLoadPublishContext(string configString, WorkLoad workLoad, string image) : base(configString)
        {
            WorkLoad = workLoad;
            Image = image;
        }

        /// <summary>
        /// 部署
        /// </summary>
        public WorkLoad WorkLoad { get; private set; }

        /// <summary>
        /// 镜像
        /// </summary>
        public string Image { get; private set; }
    }
}
