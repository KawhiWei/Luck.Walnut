using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.K8s.WorkLoads;

namespace Toyar.App.Domain.AggregateRoots.K8s.WorkLoads
{
    /// <summary>
    /// 部署领域
    /// </summary>
    public class WorkLoad : FullAggregateRoot
    {
        public WorkLoad(string appId, string chineseName, string name, string environmentName, ApplicationRuntimeTypeEnum applicationRuntimeType, DeploymentTypeEnum deploymentType, string clusterId, string nameSpace, int replicas, string? imagePullSecretId, bool isPublish = false)
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
        public DeploymentPlugin DeploymentPlugins { get; private set; }

        /// <summary>
        /// 主应用容器配置
        /// </summary>
        public ICollection<WorkLoadContainer> Containers { get; private set; } = new HashSet<WorkLoadContainer>();

        /// <summary>
        /// 初始容器配置列表
        /// </summary>
        public List<string> SideCars { get; private set; } = new List<string>();


        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; private set; } = default!;

        /// <summary>
        /// 最近修改人
        /// </summary>
        public string LastModificationUser { get; private set; } = default!;

        public WorkLoad SetSideCars(ICollection<string> sideCars)
        {
            SideCars.Clear();
            SideCars.AddRange(sideCars);
            return this;
        }

        public void SetAppId(string appId)
        {
            AppId = appId;
        }


        public WorkLoad SetImagePullSecretId(string? imagePullSecretId)
        {
            ImagePullSecretId = imagePullSecretId;
            return this;
        }

        public WorkLoad SetEnvironmentName(string environmentName)
        {
            EnvironmentName = environmentName;
            return this;
        }

        public WorkLoad SetApplicationRuntimeType(ApplicationRuntimeTypeEnum applicationRuntimeType)
        {
            ApplicationRuntimeType = applicationRuntimeType;
            return this;
        }

        public WorkLoad SetDeploymentType(DeploymentTypeEnum deploymentType)
        {
            DeploymentType = deploymentType;
            return this;
        }

        public WorkLoad SetClusterId(string clusterId)
        {
            ClusterId = clusterId;
            return this;
        }

        public WorkLoad SetNameSpace(string nameSpace)
        {
            NameSpace = nameSpace;
            return this;
        }
        public WorkLoad SetReplicas(int replicas)
        {
            Replicas = replicas;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deploymentPlugin"></param>
        /// <returns></returns>
        public WorkLoad SetDeploymentPlugin(DeploymentPlugin deploymentPlugin)
        {

            //deploymentPlugins.SetStrategy();

            return this;
        }

        public void SetIsPublish()
        {
            IsPublish = true;
        }

        /// <summary>
        /// 初始化主容器
        /// </summary>
        /// <returns></returns>
        public WorkLoad InitializeDeploymentContainer()
        {
            var deploymentContainer = new WorkLoadContainer(Id, "", "Always", "IfNotPresent", false, "");
            deploymentContainer.InitializeContainerPlugins();
            Containers.Add(deploymentContainer);
            return this;
        }

        /// <summary>
        /// 初始化K8s部分部署插件
        /// </summary>
        /// <returns></returns>
        public WorkLoad InitializeDeploymentPlugin()
        {
            var deploymentPlugins = new DeploymentPlugin(new Strategy("RollingUpdate", "1", "1"));

            DeploymentPlugins = deploymentPlugins;
            return this;
        }

        /// <summary>
        /// 修改更新策略
        /// </summary>
        /// <returns></returns>
        public WorkLoad SetStrategy(StrategyInputDto input)
        {
            DeploymentPlugins.SetStrategy(new Strategy(input.Type, input.MaxSurge, input.MaxUnavailable));
            return this;
        }
        public void CheckIsPublishWithTrue()
        {
            if (!IsPublish)
            {
                throw new BusinessException($"部署状态为未发布，请先发布部署【{Name}】");
            }
        }

    }
}
