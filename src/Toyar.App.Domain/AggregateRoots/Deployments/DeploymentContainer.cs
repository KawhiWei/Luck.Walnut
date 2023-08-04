using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Domain.AggregateRoots.Deployments
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
        /// 容器除基础配置外，其他插件列表
        /// </summary>
        public DeploymentContainerPlugin ContainerPlugins { get; private set; } = default!;

        /// <summary>
        /// 
        /// </summary>
        public Deployment Deployment { get; } = default!;


        public void InitializeContainerPlugins()
        {

            var readNess = new ContainerSurviveConfiguration("", "0.25", 8080, 10, 10);
            var liveNess = new ContainerSurviveConfiguration("", "0.25", 8080, 10, 10);

            var limit = new ContainerResourceQuantity("2", "2Gi");
            var request = new ContainerResourceQuantity("2", "2Gi");

            var containerPort = new List<ContainerPortConfiguration>
            {
                new("", 8080, "")
            };

            ContainerPlugins = new DeploymentContainerPlugin(readNess, liveNess, request, limit, containerPort);
        }
    }
}
