using k8s.Models;
using Luck.Framework.Exceptions;
using Toyar.App.Adapter.K8sAdapter.Constants;
using Toyar.App.Adapter.K8sAdapter.Factories;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.AggregateRoots.K8s.Deployments;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Adapter.K8sAdapter.WorkLoads
{
    public class WorkLoadAdaper : IWorkLoadAdaper
    {
        private readonly IKubernetesClientFactory _kubernetesClientFactory;
        private const string DeploymenExceptionErrorMsg = "未实现";
        private readonly IKubernetesCommonParamsBuild _kubernetesCommonParamsBuild;

        public WorkLoadAdaper(IKubernetesClientFactory kubernetesClientFactory, IKubernetesCommonParamsBuild kubernetesCommonParamsBuild)
        {

            _kubernetesClientFactory = kubernetesClientFactory;
            _kubernetesCommonParamsBuild = kubernetesCommonParamsBuild;
        }

        public async Task CreateWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {
            var kubernetesClient = _kubernetesClientFactory.GetKubernetesClient(kubernetesDeploymentPublishContext.ConfigString);

            switch (kubernetesDeploymentPublishContext.Deployment.DeploymentType)
            {
                case DeploymentTypeEnum.Pod:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Deployment:
                    var v1Deployment = StructureV1Deployment(kubernetesDeploymentPublishContext.Deployment);
                    break;
                case DeploymentTypeEnum.DaemonSet:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.StatefulSet:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.ReplicaSet:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.Job:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
                case DeploymentTypeEnum.CronJob:
                    throw new BusinessException($"{DeploymenExceptionErrorMsg}Pod部署");
            }
            //await kubernetesClient.CoreV1.CreateNamespaceAsync(GetV1Namespace(kubernetesNameSpacePublishContext.NameSpace));
        }



        #region 私有构建K8s对象

        private V1Deployment StructureV1Deployment(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext)
        {

            var image = kubernetesDeploymentPublishContext.Image;
            var deployment = kubernetesDeploymentPublishContext.Deployment;
            var labels = ConstantsLabels.GetKubeDefalutLabels();

            var deploymentMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(name: deployment.AppId, deployment.NameSpace);

            var v1Containers = deployment.Containers.Select(deploymentContainer => _kubernetesCommonParamsBuild.StructureV1Container(deployment.Name, $"{image}", deploymentContainer.ImagePullPolicy, deploymentContainer.ContainerPlugins)).ToList();

            var v1PodSpec = _kubernetesCommonParamsBuild.StructureV1PodSpec(v1Containers);

            var podMeta = _kubernetesCommonParamsBuild.StructureV1ObjectMeta(labels: labels);


            var v1PodtemplateSpec = _kubernetesCommonParamsBuild.StructureV1PodTemplateSpec(podMeta, v1PodSpec);

            var v1DeploymentSpec = StructureV1DeploymentSpec(deployment.Replicas, v1PodtemplateSpec);

            return new V1Deployment(metadata: deploymentMeta, spec: v1DeploymentSpec);

        }



        ///// <summary>
        ///// 创建
        ///
        ///// </summary>
        ///// <param name="deployment"></param>
        ///// <returns></returns>
        //private V1DeploymentStrategy? StructureV1DeploymentStrategy(DeploymentConfiguration deployment)
        //{
        //    return deployment.Strategy is null ? null :
        //     new V1DeploymentStrategy(new V1RollingUpdateDeployment(deployment.Strategy.MaxSurge, deployment.Strategy.MaxUnavailable), deployment.Strategy.Type);
        //}

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
