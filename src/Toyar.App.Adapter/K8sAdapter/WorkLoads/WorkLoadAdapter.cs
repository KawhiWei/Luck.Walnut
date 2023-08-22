﻿using System.Text.Json;
using k8s;
using k8s.Models;
using Luck.Framework.Exceptions;
using Toyar.App.Adapter.K8sAdapter.Constants;
using Toyar.App.Adapter.K8sAdapter.Factories;
using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Domain.AggregateRoots.ValueObjects.WorkLoadValueObjects;
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
        /// <param name="kubernetesWorkLoadPublishContext"></param>
        /// <exception cref="BusinessException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public async Task DeployWorkLoadAsync(KubernetesWorkLoadPublishContext kubernetesWorkLoadPublishContext)
        {
            kubernetesWorkLoadPublishContext.WorkLoad.SetAppId(kubernetesWorkLoadPublishContext.WorkLoad.AppId.Replace(".", "-"));
            var appId = kubernetesWorkLoadPublishContext.WorkLoad.AppId;
            var nameSpace = kubernetesWorkLoadPublishContext.WorkLoad.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesWorkLoadPublishContext.ConfigString);
            switch (kubernetesWorkLoadPublishContext.WorkLoad.WorkLoadType)
            {
                case WorkLoadTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case WorkLoadTypeEnum.Deployment:
                    var v1Deployment = await GetDeploymentByNameAndNamespaceAsync(kubernetesWorkLoadPublishContext.ConfigString,nameSpace,appId);
                    if (v1Deployment is null)
                    {
                        v1Deployment = StructureV1Deployment(kubernetesWorkLoadPublishContext);
                        await kubernetesClient.AppsV1.CreateNamespacedDeploymentAsync(v1Deployment, kubernetesWorkLoadPublishContext.WorkLoad.NameSpace);
                    }
                    else
                    {
                        await UpdateDeploymentImageAsync(kubernetesWorkLoadPublishContext, v1Deployment);
                    }
                    break;
                case WorkLoadTypeEnum.DaemonSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}DaemonSet部署");
                case WorkLoadTypeEnum.StatefulSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}StatefulSet部署");
                case WorkLoadTypeEnum.ReplicaSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}ReplicaSet部署");
                case WorkLoadTypeEnum.Job:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Job部署");
                case WorkLoadTypeEnum.CronJob:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}CronJob部署");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 更新应用部署《仅限于更新镜像》
        /// </summary>
        /// <param name="kubernetesWorkLoadPublishContext"></param>
        /// <param name="v1Deployment"></param>
        /// <exception cref="BusinessException"></exception>
        private async Task UpdateDeploymentImageAsync(KubernetesWorkLoadPublishContext kubernetesWorkLoadPublishContext,V1Deployment v1Deployment)
        {
            var image = kubernetesWorkLoadPublishContext.Image;
            var appId = kubernetesWorkLoadPublishContext.WorkLoad.AppId;
            var nameSpace = kubernetesWorkLoadPublishContext.WorkLoad.NameSpace;
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesWorkLoadPublishContext.ConfigString);
            
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
            
            var oldV1Deployment = JsonSerializer.SerializeToDocument(v1Deployment, options);
            
            foreach (var specContainer in v1Deployment.Spec.Template.Spec.Containers)
            {
                specContainer.Image = image;
            }
            v1Deployment.Spec.Strategy = StructureV1DeploymentStrategy(kubernetesWorkLoadPublishContext.WorkLoad.WorkLoadPlugins.Strategy);
            var expected = JsonSerializer.SerializeToDocument(v1Deployment);
            var patch = oldV1Deployment.CreatePatch(expected);
            await kubernetesClient.AppsV1.PatchNamespacedDeploymentAsync(new V1Patch(patch, V1Patch.PatchType.JsonPatch),appId,nameSpace);
        }
        
        public async Task DeleteWorkLoadAsync(KubernetesWorkLoadPublishContext kubernetesWorkLoadPublishContext)
        {
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesWorkLoadPublishContext.ConfigString);
            var appId = kubernetesWorkLoadPublishContext.WorkLoad.AppId;
            var nameSpace = kubernetesWorkLoadPublishContext.WorkLoad.NameSpace;
            switch (kubernetesWorkLoadPublishContext.WorkLoad.WorkLoadType)
            {
                case WorkLoadTypeEnum.Pod:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Pod部署");
                case WorkLoadTypeEnum.Deployment:
                    await kubernetesClient.AppsV1.DeleteNamespacedDeploymentAsync(appId, nameSpace);
                    break;
                case WorkLoadTypeEnum.DaemonSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}DaemonSet部署");
                case WorkLoadTypeEnum.StatefulSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}StatefulSet部署");
                case WorkLoadTypeEnum.ReplicaSet:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}ReplicaSet部署");
                case WorkLoadTypeEnum.Job:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}Job部署");
                case WorkLoadTypeEnum.CronJob:
                    throw new BusinessException($"{DeploymentExceptionErrorMsg}CronJob部署");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }



        #region 私有V1Deployment对象方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kubernetesWorkLoadPublishContext"></param>
        /// <returns></returns>
        private V1Deployment StructureV1Deployment(KubernetesWorkLoadPublishContext kubernetesWorkLoadPublishContext)
        {

            var image = kubernetesWorkLoadPublishContext.Image;
            var deployment = kubernetesWorkLoadPublishContext.WorkLoad;

            var deploymentMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(name: deployment.AppId, deployment.NameSpace);

            var v1Containers = deployment.Containers.Select(deploymentContainer => _kubernetesCommonParamsBuild.StructureV1Container(deployment.AppId,$"{deployment.AppId}-{deploymentContainer.Id}", $"{image}", deploymentContainer.ImagePullPolicy, deploymentContainer.ContainerPlugins)).ToList();

            var v1PodSpec = _kubernetesCommonParamsBuild.StructureV1PodSpec(v1Containers, deployment.Containers.First().RestartPolicy);

            var labels = ConstantsLabels.GetKubeDefalutLabels();
            labels.Add("app", deployment.AppId);
            var podMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(labels: labels);
            
            var v1PodTemplateSpec = _kubernetesCommonParamsBuild.StructureV1PodTemplateSpec(podMeta, v1PodSpec);

            var v1LabelSelector = _kubernetesCommonParamsBuild.StructureV1LabelSelector(matchLabels: labels);

            var v1DeploymentStrategy = StructureV1DeploymentStrategy(deployment.WorkLoadPlugins.Strategy);

            var v1DeploymentSpec = StructureV1DeploymentSpec(deployment.Replicas, v1PodTemplateSpec, v1DeploymentStrategy, v1LabelSelector);

            return new V1Deployment(metadata: deploymentMeta, spec: v1DeploymentSpec);

        }
        
        /// <summary>
        /// 构建更新策略
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        private static V1DeploymentStrategy StructureV1DeploymentStrategy(Strategy strategy)
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
