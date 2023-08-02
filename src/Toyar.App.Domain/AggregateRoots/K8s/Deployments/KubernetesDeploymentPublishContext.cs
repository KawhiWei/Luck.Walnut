using Toyar.App.Domain.AggregateRoots.Deployments;

namespace Toyar.App.Domain.AggregateRoots.K8s.Deployments
{
    /// <summary>
    /// 部署到K8s传输上下文
    /// </summary>
    public class KubernetesDeploymentPublishContext : KubernetesPublishBaseContext
    {
        public KubernetesDeploymentPublishContext(string configString, Deployment deployment, string image) : base(configString)
        {
            Deployment = deployment;
            Image = image;
        }

        /// <summary>
        /// 部署
        /// </summary>
        public Deployment Deployment { get; private set; }

        /// <summary>
        /// 镜像
        /// </summary>
        public string Image { get; private set; }
    }
}
