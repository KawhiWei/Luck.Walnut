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
        /// 
        /// </summary>
        /// <param name="containers"></param>
        /// <param name="restartPolicy"></param>
        /// <returns></returns>
        public V1PodSpec StructureV1PodSpec(IList<V1Container> containers, string restartPolicy)
        {
            return new V1PodSpec(containers: containers, restartPolicy: restartPolicy);
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
             DeploymentContainerPlugin containerPlugins)
        {

            var v1ResourceRequirements = StructureV1ResourceRequirements(containerPlugins.Limit, containerPlugins.Request);
            //resources: v1ResourceRequirements
            return new V1Container(name: name, image: image, imagePullPolicy: imagePullPolicy);
        }

        public V1LabelSelector StructureV1LabelSelector(IList<V1LabelSelectorRequirement>? matchExpressions = null, IDictionary<string, string>? matchLabels = null)
        {

            return new V1LabelSelector(matchLabels: matchLabels);

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
