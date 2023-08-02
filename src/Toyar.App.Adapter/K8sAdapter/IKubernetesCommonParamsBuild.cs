using k8s.Models;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Adapter.K8sAdapter
{
    public interface IKubernetesCommonParamsBuild
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        V1ObjectMeta StructureV1ObjectMeta(string? name = null, string? nameSpace = null, IDictionary<string, string>? labels = null);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="containers"></param>
        /// <returns></returns>
        V1PodSpec StructureV1PodSpec(IList<V1Container> containers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        V1PodTemplateSpec StructureV1PodTemplateSpec(V1ObjectMeta? metadata, V1PodSpec? spec);

        /// <summary>
        /// 构建K8s容器对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imagePullPolicy"></param>
        /// <param name="ContainerPlugins"></param>
        /// <returns></returns>
        V1Container StructureV1Container(string name, string image, string imagePullPolicy,
             DeploymentContainerPlugin ContainerPlugins);
    }

}
