using k8s.Models;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Adapter.K8sAdapter
{
    public class KubernetesCommonParamsBuild : IKubernetesCommonParamsBuild
    {
        #region MyRegion

        #endregion

        /// <summary>
        /// 构建K8s内V1ObjectMeta对象
        /// </summary>
        /// <returns></returns>
        public V1ObjectMeta StructureV1ObjectMeta(string? name = null, string? nameSpace = null, IDictionary<string, string>? labels = null)
        {
            return new V1ObjectMeta(name: name, namespaceProperty: nameSpace, labels: labels);
        }


        /// <summary>
        /// 创建Pod规则对象
        /// </summary>
        /// <param name="containers"></param>
        /// <param name="restartPolicy"></param>
        /// <returns></returns>
        public V1PodSpec StructureV1PodSpec(IList<V1Container> containers, string restartPolicy)
        {
            return new V1PodSpec(containers: containers, restartPolicy: restartPolicy);
        }


        /// <summary>
        /// 创建Pod模板对象
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public V1PodTemplateSpec StructureV1PodTemplateSpec(V1ObjectMeta? metadata, V1PodSpec? spec)
        {
            return new V1PodTemplateSpec(metadata, spec);
        }


        /// <summary>
        /// 构建容器对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="imagePullPolicy"></param>
        /// <param name="containerPlugins"></param>
        /// <returns></returns>
        public V1Container StructureV1Container(string name, string image, string imagePullPolicy,
            DeploymentContainerPlugin containerPlugins)
        {
            var v1ContainerPorts = containerPlugins.ContainerPorts.Select(x => new V1ContainerPort(containerPort: x.ContainerPort, name: x.Name, protocol: x.Protocol)).ToList();

            var v1ResourceRequirements = StructureV1ResourceRequirements(containerPlugins.Limit, containerPlugins.Request);
            //resources: v1ResourceRequirements
            return new V1Container(name: name, image: image, imagePullPolicy: imagePullPolicy, ports: v1ContainerPorts, resources: v1ResourceRequirements);
        }

        /// <summary>
        /// 构建Selector对象
        /// </summary>
        /// <param name="matchExpressions"></param>
        /// <param name="matchLabels"></param>
        /// <returns></returns>
        public V1LabelSelector StructureV1LabelSelector(IList<V1LabelSelectorRequirement>? matchExpressions = null, IDictionary<string, string>? matchLabels = null)
        {
            return new V1LabelSelector(matchLabels: matchLabels);
        }

        /// <summary>
        /// 构建资源占比对象
        /// </summary>
        /// <param name="limits"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        private static V1ResourceRequirements StructureV1ResourceRequirements(ContainerResourceQuantity limits, ContainerResourceQuantity requests)
        {
            var v1ResourceRequirements = new V1ResourceRequirements();

            var limitsDic = new Dictionary<string, ResourceQuantity>
            {
                { nameof(limits.Cpu).ToLower(), StructureResourceQuantity(limits.Cpu) },

                { nameof(limits.Memory).ToLower(), StructureResourceQuantity(limits.Memory) }
            };

            v1ResourceRequirements.Limits = limitsDic;
            var requestsDic = new Dictionary<string, ResourceQuantity>
            {
                { nameof(limits.Cpu).ToLower(), StructureResourceQuantity(requests.Cpu) },

                { nameof(limits.Memory).ToLower(), StructureResourceQuantity(requests.Memory) }
            };

            v1ResourceRequirements.Requests = requestsDic;


            return v1ResourceRequirements;
        }


        /// <summary>
        /// 创建容器资源使用量
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static ResourceQuantity StructureResourceQuantity(string value)
        {
            return new ResourceQuantity(value);
        }
    }
}