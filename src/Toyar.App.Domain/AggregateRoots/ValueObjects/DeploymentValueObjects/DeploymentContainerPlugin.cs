using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects
{
    public class DeploymentContainerPlugin
    {
        [JsonConstructor]
        public DeploymentContainerPlugin(ContainerSurviveConfiguration readiNess, ContainerSurviveConfiguration liveNess, ContainerResourceQuantity request, ContainerResourceQuantity limit, List<ContainerPortConfiguration> containerPorts)
        {
            ReadiNess = readiNess;
            LiveNess = liveNess;
            Request = request;
            Limit = limit;
            ContainerPorts = containerPorts;
        }

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration ReadiNess { get; private set; } = default!;

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration LiveNess { get; private set; } = default!;


        /// <summary>
        /// request资源配置
        /// </summary>
        public ContainerResourceQuantity Request { get; private set; } = default!;

        /// <summary>
        /// limit资源配置
        /// </summary>
        public ContainerResourceQuantity Limit { get; private set; } = default!;

        /// <summary>
        /// 容器端口配置
        /// </summary>
        public List<ContainerPortConfiguration> ContainerPorts { get; private set; } = new List<ContainerPortConfiguration>();

        public void SetReadiNess(ContainerSurviveConfiguration readiNess)
        {
            ReadiNess = readiNess;
        }


        public void SetLiveNess(ContainerSurviveConfiguration liveNess)
        {
            LiveNess = liveNess;
        }


        public void SetRequest(ContainerResourceQuantity request)
        {
            Request = request;
        }

        public void SetLimit(ContainerResourceQuantity limit)
        {
            Limit = limit;
        }


        public void SetContainerPorts(List<ContainerPortConfiguration> containerPort)
        {
            ContainerPorts = containerPort;
        }
    }
}
