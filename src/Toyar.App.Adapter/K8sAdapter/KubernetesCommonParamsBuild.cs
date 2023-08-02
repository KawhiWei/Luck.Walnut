using k8s.Models;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Adapter.K8sAdapter
{
    public class KubernetesCommonParamsBuild : IKubernetesCommonParamsBuild
    {

        /// <summary>
        /// 构建K8s内V1ObjectMeta对象
        /// </summary>
        /// <returns></returns>
        public V1ObjectMeta StructureV1ObjectMeta(string? name = null, string? nameSpace = null, IDictionary<string, string>? labels = null)
        {
            return new V1ObjectMeta(name: name, namespaceProperty: nameSpace, labels: labels);
        }


        public V1PodSpec StructureV1PodSpec(IList<V1Container> containers)
        {
            return new V1PodSpec(containers: containers);
        }


        /// <summary>
        /// /创建Pod模板规格
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public V1PodTemplateSpec StructureV1PodTemplateSpec(V1ObjectMeta? metadata, V1PodSpec? spec)
        {
            return new V1PodTemplateSpec(metadata, spec);
        }


        public V1Container StructureV1Container(string name, string image, string imagePullPolicy,
             DeploymentContainerPlugin ContainerPlugins)
        {

            var v1ResourceRequirements = StructureV1ResourceRequirements(ContainerPlugins.Limit, ContainerPlugins.Request);

            return new V1Container(name: name, image: image, resources: v1ResourceRequirements, imagePullPolicy: imagePullPolicy);
        }







        private V1ResourceRequirements StructureV1ResourceRequirements(ContainerResourceQuantity limits, ContainerResourceQuantity requests)
        {
            var v1ResourceRequirements = new V1ResourceRequirements();

            Dictionary<string, ResourceQuantity> limitsDic = new Dictionary<string, ResourceQuantity>
            {
                { nameof(limits.Cpu).ToLower(), StructureResourceQuantity(limits.Cpu) },

                { nameof(limits.Memory).ToLower(), StructureResourceQuantity(limits.Memory) }
            };

            v1ResourceRequirements.Limits = limitsDic;
            Dictionary<string, ResourceQuantity> requestsDic = new Dictionary<string, ResourceQuantity>
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
