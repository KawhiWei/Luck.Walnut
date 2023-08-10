using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects
{
    public class DeploymentContainerPlugin
    {
        [JsonConstructor]
        public DeploymentContainerPlugin(ContainerSurviveConfiguration readNess, ContainerSurviveConfiguration liveNess, ContainerResourceQuantity request, ContainerResourceQuantity limit, List<ContainerPortConfiguration> containerPorts,Dictionary<string, string> env)
        {
            ReadNess = readNess;
            LiveNess = liveNess;
            Request = request;
            Limit = limit;
            ContainerPorts = containerPorts;
            Env = env;
        }

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration ReadNess { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration LiveNess { get; private set; }


        /// <summary>
        /// request资源配置
        /// </summary>
        public ContainerResourceQuantity Request { get; private set; }

        /// <summary>
        /// limit资源配置
        /// </summary>
        public ContainerResourceQuantity Limit { get; private set; }

        /// <summary>
        /// 容器端口配置
        /// </summary>
        public List<ContainerPortConfiguration> ContainerPorts { get; private set; }

        /// <summary>
        /// 环境变量
        /// </summary>
        public Dictionary<string, string> Env { get; private set; } 
        
        

        public void SetReadNess(ContainerSurviveConfiguration readNess)
        {
            ReadNess = readNess;
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
