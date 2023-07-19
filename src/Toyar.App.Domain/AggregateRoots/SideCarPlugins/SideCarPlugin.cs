
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;
using Toyar.App.Dto.SideCarPlugins;
using Toyar.App.Dto.ValueObjects.DeploymentValueObjects;

namespace Luck.Walnut.Kube.Domain.AggregateRoots.SideCar
{
    /// <summary>
    /// 初始容器配置
    /// 五一更名为    SideCarPlugin
    /// </summary>
    public class SideCarPlugin : FullAggregateRoot
    {
        public SideCarPlugin(string containerName, string image, string restartPolicy, string imagePullPolicy)
        {
            ContainerName = containerName;
            Image = image;
            RestartPolicy = restartPolicy;
            ImagePullPolicy = imagePullPolicy;
        }


        /// <summary>
        /// 容器名称
        /// </summary>
        public string ContainerName { get; private set; }

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
        public DeploymentContainerPlugin? ContainerPlugins { get; private set; }

        public SideCarPlugin Update(SideCarPluginInputDto input)
        {
            ContainerName = input.ContainerName;
            RestartPolicy = input.RestartPolicy;
            ImagePullPolicy = input.ImagePullPolicy;
            Image = input.Image;
            return this;
        }
    }
}