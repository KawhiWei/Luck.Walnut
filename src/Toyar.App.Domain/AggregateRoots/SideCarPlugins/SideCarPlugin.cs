
using Toyar.App.Domain.AggregateRoots.ValueObject.DeploymentValueObjects;
using Toyar.App.Dto.K8s.DeploymentsBaseDto;
using Toyar.App.Dto.SideCarPlugins;

namespace Luck.Walnut.Kube.Domain.AggregateRoots.SideCarPlugins
{
    /// <summary>
    /// 初始容器配置
    /// 五一更名为    SideCarPlugin
    /// </summary>
    public class SideCarPlugin : FullAggregateRoot
    {
        public SideCarPlugin(string containerName, string? image, string restartPolicy, string imagePullPolicy)
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
        public string? Image { get; private set; }

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
        public List<KeyValuePair<string, string>> Environments { get; private set; } = default!;

        /// <summary>
        /// 容器端口配置
        /// </summary>
        public ICollection<ContainerPortConfiguration> ContainerPortConfigurations { get; private set; } = new HashSet<ContainerPortConfiguration>();

        public SideCarPlugin Update(SideCarPluginInputDto input)
        {
            ContainerName = input.ContainerName;
            RestartPolicy = input.RestartPolicy;
            ImagePullPolicy = input.ImagePullPolicy;
            Image = input.Image;
            return this;
        }

        public SideCarPlugin SetReadinessProbe(ContainerSurviveConfigurationDto? readinessProbe)
        {
            if (readinessProbe is null)
            {
                return this;
            }

            ReadinessProbe = new ContainerSurviveConfiguration(readinessProbe.Scheme, readinessProbe.Path, readinessProbe.Port, readinessProbe.InitialDelaySeconds, readinessProbe.PeriodSeconds);

            return this;
        }

        public SideCarPlugin SetLiveNessProbe(ContainerSurviveConfigurationDto? liveNessProbe)
        {
            if (liveNessProbe is null)
            {
                return this;
            }

            LiveNessProbe = new ContainerSurviveConfiguration(liveNessProbe.Scheme, liveNessProbe.Path, liveNessProbe.Port, liveNessProbe.InitialDelaySeconds, liveNessProbe.PeriodSeconds);
            return this;
        }

        public SideCarPlugin SetLimits(ContainerResourceQuantityDto? limits)
        {
            if (limits is null)
            {
                return this;
            }

            Limits = new ContainerResourceQuantity();
            if (limits.Cpu is not null)
            {
                Limits.SetCpu(limits.Cpu);
            }

            if (limits.Memory is not null)
            {
                Limits.SetMemory(limits.Memory);
            }

            return this;
        }

        public SideCarPlugin SetRequests(ContainerResourceQuantityDto? requests)
        {
            if (requests is null)
            {
                return this;
            }

            Requests = new ContainerResourceQuantity();
            if (requests.Cpu is not null)
            {
                Requests.SetCpu(requests.Cpu);
            }

            if (requests.Memory is not null)
            {
                Requests.SetMemory(requests.Memory);
            }

            return this;
        }

        public SideCarPlugin SetEnvironments(List<KeyValuePair<string, string>>? environments)
        {
            Environments = environments ?? new List<KeyValuePair<string, string>>();
            return this;
        }


        public SideCarPlugin SetContainerPortConfigurations(List<ContainerPortConfigurationDto>? containerPortConfigurations)
        {
            return this;
        }
    }
}