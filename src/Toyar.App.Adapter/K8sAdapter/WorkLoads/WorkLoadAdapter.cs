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
        private readonly IKubernetesClientFactory _kubernetesClientFactory;
        private const string DeploymentExceptionErrorMsg = "未实现";
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
        public async Task CreateDeployWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);
            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment = StructureV1Deployment(kubernetesDeploymentPublishContext);
                    await kubernetesClient.AppsV1.CreateNamespacedDeploymentAsync(v1Deployment, kubernetesDeploymentPublishContext.Deployment.NameSpace);
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
            //await kubernetesClient.CoreV1.CreateNamespaceAsync(GetV1Namespace(kubernetesNameSpacePublishContext.NameSpace));
        }

        /// <summary>
        /// 更新应用部署《仅限于更新镜像》
        /// </summary>
        /// <param name="kubernetesDeploymentPublishContext"></param>
        /// <exception cref="BusinessException"></exception>
        public async Task UpdateDeployImageWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            var image = kubernetesDeploymentPublishContext.Image;
            kubernetesDeploymentPublishContext.Deployment.SetAppId(kubernetesDeploymentPublishContext.Deployment.AppId.Replace(".", "-"));
            var appId = kubernetesDeploymentPublishContext.Deployment.AppId;
            var nameSpace = kubernetesDeploymentPublishContext.Deployment.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);
            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment= await kubernetesClient.AppsV1.ReadNamespacedDeploymentAsync(appId,nameSpace);
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
                    throw new BusinessException($"不存在的部署类型！请联系开发人员");
            }
        }
        
        /// <summary>
        /// 更新应用部署《仅限于更新镜像》
        /// </summary>
        /// <param name="kubernetesDeploymentPublishContext"></param>
        /// <exception cref="BusinessException"></exception>
        public async Task UpdateDeployConfigWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            var image = kubernetesDeploymentPublishContext.Image;
            kubernetesDeploymentPublishContext.Deployment.SetAppId(kubernetesDeploymentPublishContext.Deployment.AppId.Replace(".", "-"));
            var appId = kubernetesDeploymentPublishContext.Deployment.AppId;
            var nameSpace = kubernetesDeploymentPublishContext.Deployment.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);
            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment= await kubernetesClient.AppsV1.ReadNamespacedDeploymentAsync(appId,nameSpace);
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
                    throw new BusinessException($"不存在的部署类型！请联系开发人员");
            }
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



        #region 私有构建K8s中V1Deployment对象

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

            var v1Containers = deployment.Containers.Select(deploymentContainer => _kubernetesCommonParamsBuild.StructureV1Container($"{deployment.AppId}-{deploymentContainer.Id}", $"{image}", deploymentContainer.ImagePullPolicy, deploymentContainer.ContainerPlugins)).ToList();

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
        #endregion


    }
}
