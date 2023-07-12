using Toyar.App.Domain.AggregateRoots.ValueObject.DeploymentValueObjects;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.K8s.Deployments
{
    /// <summary>
    /// 部署领域
    /// </summary>
    public class Deployment : FullAggregateRoot
    {
        public Deployment(string appId, string chineseName, string name, string environmentName, ApplicationRuntimeTypeEnum applicationRuntimeType, DeploymentTypeEnum deploymentType, string clusterId, string nameSpace, int replicas, string? imagePullSecretId, bool isPublish)
        {
            AppId = appId;
            ChineseName = chineseName;
            Name = name;
            EnvironmentName = environmentName;
            ApplicationRuntimeType = applicationRuntimeType;
            DeploymentType = deploymentType;
            ClusterId = clusterId;
            NameSpace = nameSpace;
            Replicas = replicas;
            ImagePullSecretId = imagePullSecretId;
            IsPublish = isPublish;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName { get; private set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 部署环境
        /// </summary>
        /// <summary>
        /// 部署环境
        /// </summary>
        public string EnvironmentName { get; private set; }

        /// <summary>
        /// 应用运行时类型
        /// </summary>
        public ApplicationRuntimeTypeEnum ApplicationRuntimeType { get; private set; }

        /// <summary>
        /// 部署类型
        /// </summary>
        public DeploymentTypeEnum DeploymentType { get; private set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string ClusterId { get; private set; }

        /// <summary>
        /// 命名空间Id
        /// </summary>
        public string NameSpace { get; private set; }

        /// <summary>
        /// 部署副本数量
        /// </summary>
        public int Replicas { get; private set; }

        /// <summary>
        /// 镜像拉取证书
        /// </summary>
        public string? ImagePullSecretId { get; private set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; private set; }

        /// <summary>
        /// Deployment除基础配置外，其他插件列表，字典Key是约定，value是详细的配置
        /// </summary>
        public IDictionary<string, string>? DeploymentPlugins { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// 主应用容器配置
        /// </summary>
        public ICollection<DeploymentContainer> Containers { get; private set; } = new HashSet<DeploymentContainer>();

        /// <summary>
        /// 初始容器配置列表
        /// </summary>
        public ICollection<string>? SideCars { get; private set; } = new HashSet<string>();
    }
}
