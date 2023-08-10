using System.Text.Json;
using k8s;
using k8s.Models;
using Luck.Framework.Exceptions;
using Toyar.App.Adapter.K8sAdapter.Constants;
using Toyar.App.Adapter.K8sAdapter.Factories;
using Toyar.App.Domain.AggregateRoots.K8s.Deployments;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Adapter.K8sAdapter.WorkLoads
{
    public class WorkLoadAdapter : IWorkLoadAdapter
    {
        private const string DeploymentExceptionErrorMsg = "未实现";
        private readonly IKubernetesClientFactory _kubernetesClientFactory;
        private readonly IKubernetesCommonParamsBuild _kubernetesCommonParamsBuild;

        public WorkLoadAdapter(IKubernetesClientFactory kubernetesClientFactory, IKubernetesCommonParamsBuild kubernetesCommonParamsBuild)
        {

            _kubernetesClientFactory = kubernetesClientFactory;
            _kubernetesCommonParamsBuild = kubernetesCommonParamsBuild;
        }

        /// <summary>
        /// 创建应用部署
        /// </summary>
        /// <param name="kubernetesDeploymentPublishContext"></param>
        /// <exception cref="BusinessException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task DeployWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            kubernetesDeploymentPublishContext.Deployment.SetAppId(kubernetesDeploymentPublishContext.Deployment.AppId.Replace(".", "-"));
            var appId = kubernetesDeploymentPublishContext.Deployment.AppId;
            var nameSpace = kubernetesDeploymentPublishContext.Deployment.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);
            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment = await GetDeploymentByNameAndNamespaceAsync(kubernetesDeploymentPublishContext.ConfigString,nameSpace,appId);
                    if (v1Deployment is null)
                    {
                        v1Deployment = StructureV1Deployment(kubernetesDeploymentPublishContext);
                        await kubernetesClient.AppsV1.CreateNamespacedDeploymentAsync(v1Deployment, kubernetesDeploymentPublishContext.Deployment.NameSpace);
                    }
                    else
                    {
                        await UpdateDeploymentImageAsync(kubernetesDeploymentPublishContext, v1Deployment);
                    }
                    break;
                case DeploymentTypeEnum.DaemonSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}DaemonSet部署");
                case DeploymentTypeEnum.StatefulSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}StatefulSet部署");
                case DeploymentTypeEnum.ReplicaSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}ReplicaSet部署");
                case DeploymentTypeEnum.Job:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Job部署");
                case DeploymentTypeEnum.CronJob:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}CronJob部署");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 更新应用部署《仅限于更新镜像》
        /// </summary>
        /// <param name="kubernetesDeploymentPublishContext"></param>
        /// <param name="v1Deployment"></param>
        /// <exception cref="BusinessException"></exception>
        private async Task UpdateDeploymentImageAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext,V1Deployment v1Deployment)
        {
            var image = kubernetesDeploymentPublishContext.Image;
            var appId = kubernetesDeploymentPublishContext.Deployment.AppId;
            var nameSpace = kubernetesDeploymentPublishContext.Deployment.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
            var oldV1Deployment = JsonSerializer.SerializeToDocument(v1Deployment, options);
            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var restart = new Dictionary<string, string>
            {
                ["date"] = now.ToString()
            };
            foreach (var specContainer in v1Deployment.Spec.Template.Spec.Containers)
            {
                specContainer.Image = image;

            }
            var expected = JsonSerializer.SerializeToDocument(v1Deployment);
            var patch = oldV1Deployment.CreatePatch(expected);
            await kubernetesClient.AppsV1.PatchNamespacedDeploymentAsync(new V1Patch(patch, V1Patch.PatchType.JsonPatch),appId,nameSpace);
        }
        
        public async Task DeleteWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);

            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment = StructureV1Deployment(kubernetesDeploymentPublishContext);
                    break;
                case DeploymentTypeEnum.DaemonSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}DaemonSet部署");
                case DeploymentTypeEnum.StatefulSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}StatefulSet部署");
                case DeploymentTypeEnum.ReplicaSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}ReplicaSet部署");
                case DeploymentTypeEnum.Job:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Job部署");
                case DeploymentTypeEnum.CronJob:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}CronJob部署");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        #region 私有V1Deployment对象方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kubernetesDeploymentPublishContext"></param>
        /// <returns></returns>
        private V1Deployment StructureV1Deployment(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {

            var image = kubernetesDeploymentPublishContext.Image;
            var deployment = kubernetesDeploymentPublishContext.Deployment;

            var deploymentMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(name: deployment.AppId, deployment.NameSpace);

            var v1Containers = deployment.Containers.Select(deploymentContainer => _kubernetesCommonParamsBuild.StructureV1Container(deployment.AppId,$"{deployment.AppId}-{deploymentContainer.Id}", $"{image}", deploymentContainer.ImagePullPolicy, deploymentContainer.ContainerPlugins)).ToList();

            var v1PodSpec = _kubernetesCommonParamsBuild.StructureV1PodSpec(v1Containers, deployment.Containers.First().RestartPolicy);

            var labels = ConstantsLabels.GetKubeDefalutLabels();
            labels.Add("app", deployment.AppId);
            var podMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(labels: labels);
            
            var v1PodTemplateSpec = _kubernetesCommonParamsBuild.StructureV1PodTemplateSpec(podMeta, v1PodSpec);

            var v1LabelSelector = _kubernetesCommonParamsBuild.StructureV1LabelSelector(matchLabels: labels);

            var v1DeploymentStrategy = StructureV1DeploymentStrategy(deployment.DeploymentPlugins.Strategy);

            var v1DeploymentSpec = StructureV1DeploymentSpec(deployment.Replicas, v1PodTemplateSpec, v1DeploymentStrategy, v1LabelSelector);

            return new V1Deployment(metadata: deploymentMeta, spec: v1DeploymentSpec);

        }
        
        /// <summary>
        /// 构建更新策略
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        private static V1DeploymentStrategy? StructureV1DeploymentStrategy(Strategy strategy)
        {
            return new V1DeploymentStrategy(new V1RollingUpdateDeployment(strategy.MaxSurge, strategy.MaxUnavailable), strategy.Type);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replicas"></param>
        /// <param name="v1PodTemplateSpec"></param>
        /// <param name="v1DeploymentStrategy"></param>
        /// <param name="v1LabelSelector"></param>
        /// <returns></returns>
        private V1DeploymentSpec StructureV1DeploymentSpec(int replicas, V1PodTemplateSpec v1PodTemplateSpec, V1DeploymentStrategy? v1DeploymentStrategy = null, V1LabelSelector? v1LabelSelector = null)
        {
            return new V1DeploymentSpec()
            {
                Replicas = replicas,
                Strategy = v1DeploymentStrategy,
                Selector = v1LabelSelector,
                Template = v1PodTemplateSpec
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configString"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<V1Deployment?> GetDeploymentByNameAndNamespaceAsync(string configString,string nameSpace,string name)
        {
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(configString);
            //暂时曲线救国，因为K8sApi标准是如果查询一个不存在的deployment的情况http状态码返回404，所以现在只能暂时这么写；
            var v1Deployments = await kubernetesClient.AppsV1.ListNamespacedDeploymentAsync(nameSpace);
            return v1Deployments.Items.Count<=0?null:v1Deployments.Items.FirstOrDefault(x=>x.Metadata.Name==name);
        }
        #endregion
    }
}
