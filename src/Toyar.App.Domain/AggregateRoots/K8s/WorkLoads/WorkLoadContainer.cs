
using Toyar.App.Domain.AggregateRoots.ValueObjects.WorkLoadValueObjects;

namespace Toyar.App.Domain.AggregateRoots.K8s.WorkLoads
{
    public class WorkLoadContainer : FullEntity
    {
        public WorkLoadContainer(string workLoadId, string containerName, string restartPolicy, string imagePullPolicy, bool isInitContainer, string image)
        {
            WorkLoadId = workLoadId;
            ContainerName = containerName;
            RestartPolicy = restartPolicy;
            ImagePullPolicy = imagePullPolicy;
            IsInitContainer = isInitContainer;
            Image = image;

        }
        /// <summary>
        /// 流水线Id
        /// </summary>
        public string WorkLoadId { get; private set; }

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
        public WorkLoadContainerPlugin ContainerPlugins { get; private set; } = default!;

        /// <summary>
        /// 
        /// </summary>
        public WorkLoad WorkLoad { get; } = default!;

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; private set; } = default!;

        /// <summary>
        /// 最近修改人
        /// </summary>
        public string LastModificationUser { get; private set; } = default!;

        public void InitializeContainerPlugins()
        {
            var containerPort = new List<ContainerPortConfiguration>();
            var env = new Dictionary<string, string>();
            ContainerPlugins = new WorkLoadContainerPlugin(containerPort,env);
        }
    }
}
