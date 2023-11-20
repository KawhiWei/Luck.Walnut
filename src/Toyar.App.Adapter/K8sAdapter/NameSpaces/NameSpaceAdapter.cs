using k8s.Models;
using System.Text.Json;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Adapter.K8sAdapter.Factories;
using k8s;
using Toyar.App.Infrastructure;
using Toyar.App.Adapter.K8sAdapter.Constants;

namespace Toyar.App.Adapter.K8sAdapter.NameSpaces
{
    public class NameSpaceAdapter(IKubernetesClientFactory kubernetesClientFactory) : INameSpaceAdapter
    {
        public async Task CreateNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext)
        {
            var kubernetesClient = kubernetesClientFactory.GetKubernetesClient(kubernetesNameSpacePublishContext.ConfigString);
            await kubernetesClient.CoreV1.CreateNamespaceAsync(GetV1Namespace(kubernetesNameSpacePublishContext.NameSpace));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kubernetesNameSpacePublishContext"></param>
        /// <returns></returns>
        public async Task UpdateNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext)
        {
            var kubernetesClient = kubernetesClientFactory.GetKubernetesClient(kubernetesNameSpacePublishContext.ConfigString);
            var v1NameSpace = await kubernetesClient.CoreV1.ReadNamespaceAsync(kubernetesNameSpacePublishContext.NameSpace.Name);
            await kubernetesClient.CoreV1.PatchNamespaceAsync(GetPatchNameSpaceV1NameSpace(kubernetesNameSpacePublishContext.NameSpace, v1NameSpace), kubernetesNameSpacePublishContext.NameSpace.Name);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="kubernetesNameSpacePublishContext"></param>
        public async Task DeleteNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext)
        {
            var kubernetesClient = kubernetesClientFactory.GetKubernetesClient(kubernetesNameSpacePublishContext.ConfigString);
            await kubernetesClient.CoreV1.DeleteNamespaceAsync(kubernetesNameSpacePublishContext.NameSpace.Name);
        }

        /// <summary>
        /// 转换为K8s对象
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        private static V1Namespace GetV1Namespace(NameSpace nameSpace)
        {
            var labels = ConstantsLabels.GetKubeDefalutLabels();
            return new V1Namespace()
            {
                Metadata = new V1ObjectMeta()
                {
                    Name = nameSpace.Name,
                    Labels = labels
                }
            };

        }


        /// <summary>
        /// 转换为K8s对象
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="oldV1Namespace"></param>
        /// <returns></returns>
        private static V1Patch GetPatchNameSpaceV1NameSpace(NameSpace nameSpace, V1Namespace oldV1Namespace)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };

            var old = JsonSerializer.SerializeToDocument(oldV1Namespace, options);
            var expected = JsonSerializer.SerializeToDocument(oldV1Namespace);
            var patch = old.CreatePatch(expected);
            return new V1Patch(patch, V1Patch.PatchType.JsonPatch);
            //var daemonSet = await client.AppsV1.ReadNamespacedDaemonSetAsync(name, @namespace);
            //var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
            //var old = JsonSerializer.SerializeToDocument(daemonSet, options);
            //var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            //var restart = new Dictionary<string, string>
            //{
            //    ["date"] = now.ToString()
            //};

            //daemonSet.Spec.Template.Metadata.Annotations = restart;

            //var expected = JsonSerializer.SerializeToDocument(daemonSet);

            //var patch = old.CreatePatch(expected);
        }
    }
}
