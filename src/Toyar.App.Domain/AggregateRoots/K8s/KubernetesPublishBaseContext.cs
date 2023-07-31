using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;

namespace Toyar.App.Domain.AggregateRoots.K8s
{
    /// <summary>
    /// K8s相应配置发布传输上下文
    /// </summary>
    public abstract class KubernetesPublishBaseContext
    {
        public KubernetesPublishBaseContext(string config)
        {
            ConfigString = config;
        }

        /// <summary>
        /// 集群连接配置
        /// </summary>

        public string ConfigString { get; private set; }

    }
}
