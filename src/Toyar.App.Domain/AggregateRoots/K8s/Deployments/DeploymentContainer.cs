using Toyar.App.Domain.AggregateRoots.ValueObject.DeploymentValueObjects;

namespace Toyar.App.Domain.AggregateRoots.K8s.Deployments
{
    public class DeploymentContainer : FullEntity
    {
        public DeploymentContainer(string deploymentId, string containerName, string restartPolicy, string imagePullPolicy, bool isInitContainer, string image)
        {
            DeploymentId = deploymentId;
            ContainerName = containerName;
            RestartPolicy = restartPolicy;
            ImagePullPolicy = imagePullPolicy;
            IsInitContainer = isInitContainer;
            Image = image;

        }
        /// <summary>
        /// 流水线Id
        /// </summary>
        public string DeploymentId { get; private set; }

        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { get; private set; }

        /// <summary>
        /// 是否初始容器
        /// </summary>
        public bool IsInitContainer { get; private set; }

        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Image { get; private set; }

        /// <summary>
        /// 重启策略
        /// </summary>

        public string RestartPolicy { get; private set; }

        /// <summary>
        /// 镜像拉取策略
        /// </summary>

        public string ImagePullPolicy { get; private set; }

        /// <summary>
        /// 准备完成探针配置
        /// </summary>
        public ContainerSurviveConfiguration? ReadinessProbe { get; private set; }

        /// <summary>
        /// 存活探针配置
        /// </summary>
        public ContainerSurviveConfiguration? LiveNessProbe { get; private set; }

        /// <summary>
        /// 容器Cpu资源限制
        /// </summary>
        public ContainerResourceQuantity? Limits { get; private set; }

        /// <summary>
        /// 容器内存资源限制
        /// </summary>
        public ContainerResourceQuantity? Requests { get; private set; }

        /// <summary>
        /// 环境变量
        /// </summary>
        public List<KeyValuePair<string, string>>? Environments { get; private set; } = default!;

        /// <summary>
        /// 容器端口配置
        /// </summary>
        public ICollection<ContainerPortConfiguration>? ContainerPortConfigurations { get; private set; } = new HashSet<ContainerPortConfiguration>();

        /// <summary>
        /// 
        /// </summary>
        public Deployment Deployment { get; } = default!;

    }
}
