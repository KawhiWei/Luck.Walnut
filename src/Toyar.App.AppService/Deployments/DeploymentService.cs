using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.AppService.K8s.Clusters;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.AggregateRoots.K8s.Deployments;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Deployments;

namespace Toyar.App.AppService.Deployments;

public class DeploymentService : IDeploymentService
{
    private readonly IDeploymentRepository _deploymentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClusterService _clusterService;

    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public DeploymentService(IDeploymentRepository deploymentRepository, IUnitOfWork unitOfWork, IClusterService clusterService = null)
    {
        _deploymentRepository = deploymentRepository;
        _unitOfWork = unitOfWork;
        _clusterService = clusterService;
    }



    public async Task CreateDeploymentAsync(DeploymentInputDto input)
    {
        Deployment deployment = new(input.AppId, input.ChineseName, input.Name, input.EnvironmentName, input.ApplicationRuntimeType, input.DeploymentType, input.ClusterId, input.NameSpace, input.Replicas, input.ImagePullSecretId);
        if (input.SideCarPlugins.Any())
        {
            deployment.SetSideCars(input.SideCarPlugins);
        }

        deployment.InitializeDeploymentPlugin();
        deployment.InitializeDeploymentContainer();
        _deploymentRepository.Add(deployment);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateDeploymentAsync(string id, DeploymentInputDto input)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);

        deployment.SetSideCars(input.SideCarPlugins)
            .SetReplicas(input.Replicas)
            .SetImagePullSecretId(input.ImagePullSecretId)
            .SetDeploymentType(input.DeploymentType)
            .SetEnvironmentName(input.EnvironmentName)
            .SetApplicationRuntimeType(input.ApplicationRuntimeType)
            .SetClusterId(input.ClusterId)
            .SetNameSpace(input.NameSpace);
        await _unitOfWork.CommitAsync();
    }

    public async Task PublishDeploymentAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);

        var cluster = await _clusterService.CheckAndGetCluster(deployment.ClusterId);



        deployment.SetIsPublish();
        await _unitOfWork.CommitAsync();
    }

    public async Task DeployByDeploymentIdAsync(string id, string imageVersion)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        deployment.CheckIsPublishWithTrue();
        var cluster = await _clusterService.CheckAndGetCluster(deployment.ClusterId);
        var kubernetesDeploymentPublishContext = StructureKubernetesDeploymentPublishContext(cluster.Config, deployment, imageVersion);



    }


    public async Task DeleteDeploymentAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        _deploymentRepository.Remove(deployment);
        await _unitOfWork.CommitAsync();
    }

    private async Task<Deployment> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _deploymentRepository.FirstOrDefaultByIdAsync(id);
        return deployment is null ? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}") : deployment;
    }

    /// <summary>
    /// 构建推送到K8s上下文
    /// </summary>
    /// <param name="nameSpace"></param>
    /// <param name="connectStr"></param>
    /// <returns></returns>
    private static KubernetesDeploymentPublishContext StructureKubernetesDeploymentPublishContext(string connectStr, Deployment deployment, string image)
    {
        return new KubernetesDeploymentPublishContext(connectStr, deployment, image);
    }
}
