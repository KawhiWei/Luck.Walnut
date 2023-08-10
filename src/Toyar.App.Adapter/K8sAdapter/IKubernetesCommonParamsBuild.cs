using k8s.Models;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Adapter.K8sAdapter
{
    public interface IKubernetesCommonParamsBuild:IScopedDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nameSpace"></param>
        /// <param name="labels"></param>
        /// <returns></returns>
        V1ObjectMeta StructureV1ObjectMeta(string? name = null, string? nameSpace = null, IDictionary<string, string>? labels = null);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="containers"></param>
        /// <param name="restartPolicy"></param>
        /// <returns></returns>
        V1PodSpec  StructureV1PodSpec(IList<V1Container> containers,string restartPolicy);

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
        /// <param name="appId"></param>
        /// <param name="name"></param>
        /// <param name="image"></param>
        /// <param name="imagePullPolicy"></param>
        /// <param name="containerPlugins"></param>
        /// <returns></returns>
        V1Container StructureV1Container(string appId,string name, string image, string imagePullPolicy,
             DeploymentContainerPlugin containerPlugins);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchExpressions"></param>
        /// <param name="matchLabels"></param>
        /// <returns></returns>
        V1LabelSelector StructureV1LabelSelector(IList<V1LabelSelectorRequirement>? matchExpressions = null,
            IDictionary<string, string>? matchLabels = null);

    }

}
