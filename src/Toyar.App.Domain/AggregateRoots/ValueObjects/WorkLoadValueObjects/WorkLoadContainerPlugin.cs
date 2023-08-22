using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.WorkLoadValueObjects
{
    public class WorkLoadContainerPlugin
    {
        [JsonConstructor]
        public WorkLoadContainerPlugin(List<ContainerPortConfiguration> containerPorts,Dictionary<string, string> env,ContainerSurviveConfiguration? readNess=null, ContainerSurviveConfiguration? liveNess=null, ContainerResourceQuantity? request=null, ContainerResourceQuantity? limit=null)
        {
            ContainerPorts = containerPorts;
            Env = env;
            ReadNess = readNess;
            LiveNess = liveNess;
            Request = request;
            Limit = limit;

        }

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration? ReadNess { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ContainerSurviveConfiguration? LiveNess { get; private set; }


        /// <summary>
        /// request资源配置
        /// </summary>
        public ContainerResourceQuantity? Request { get; private set; }

        /// <summary>
        /// limit资源配置
        /// </summary>
        public ContainerResourceQuantity? Limit { get; private set; }

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
