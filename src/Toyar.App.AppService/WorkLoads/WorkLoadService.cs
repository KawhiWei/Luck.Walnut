using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Adapter.K8sAdapter.WorkLoads;
using Toyar.App.AppService.K8s.Clusters;
using Toyar.App.Domain.AggregateRoots.WorkLoads;
using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.WorkLoads;

namespace Toyar.App.AppService.WorkLoads;

public class WorkLoadService : IWorkLoadService
{
    private readonly IWorkLoadRepository _workLoadRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClusterService _clusterService;
    private readonly IWorkLoadAdapter _workLoadAdapter;
    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public WorkLoadService(IWorkLoadRepository workLoadRepository, IUnitOfWork unitOfWork, IWorkLoadAdapter workLoadAdapter, IClusterService clusterService)
    {
        _workLoadRepository = workLoadRepository;
        _unitOfWork = unitOfWork;
        _workLoadAdapter = workLoadAdapter;
        _clusterService = clusterService;
    }



    public async Task CreateWorkLoadAsync(WorkLoadInputDto input)
    {
        WorkLoad workLoad = new(input.AppId, input.ChineseName, input.Name, input.EnvironmentName, input.ApplicationRuntimeType, input.DeploymentType, input.ClusterId, input.NameSpace, input.Replicas, input.ImagePullSecretId);
        if (input.SideCarPlugins.Any())
        {
            workLoad.SetSideCars(input.SideCarPlugins);
        }

        workLoad.InitializeDeploymentPlugin();
        workLoad.InitializeDeploymentContainer();
        _workLoadRepository.Add(workLoad);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateWorkLoadAsync(string id, WorkLoadInputDto input)
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
    
    /// <summary>
    /// 修改更新策略
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    public async Task UpdateWorkLoadStrategyAsync(string id, StrategyInputDto input)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        deployment.SetStrategy(input);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 发布部署
    /// </summary>
    /// <param name="id"></param>
    public async Task PublishWorkLoadAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        deployment.SetIsPublish();
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 部署应用
    /// </summary>
    /// <param name="id"></param>
    /// <param name="imageVersion"></param>
    public async Task DeployApplicationAsync(string id, string imageVersion)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        deployment.CheckIsPublishWithTrue();
        var cluster = await _clusterService.CheckAndGetCluster(deployment.ClusterId);
        var kubernetesDeploymentPublishContext = StructureKubernetesDeploymentPublishContext(cluster.Config, deployment, $"registry.cn-hangzhou.aliyuncs.com/toyar/{deployment.AppId}:{imageVersion}");
        await _workLoadAdapter.DeployWorkLoadAsync(kubernetesDeploymentPublishContext);
    }


    /// <summary>
    /// 删除部署
    /// </summary>
    /// <param name="id"></param>
    public async Task DeleteDeploymentAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        _workLoadRepository.Remove(deployment);
        await _unitOfWork.CommitAsync();
    }
    
    /// <summary>
    /// 校验并获取一个部署
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="BusinessException"></exception>
    private async Task<WorkLoad> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _workLoadRepository.FirstOrDefaultByIdAsync(id);
        return deployment ?? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}");
    }

    /// <summary>
    /// 构建推送到K8s上下文
    /// </summary>
    /// <param name="workLoad"></param>
    /// <param name="connectStr"></param>
    /// <param name="image"></param>
    /// <returns></returns>
    private static KubernetesWorkLoadPublishContext StructureKubernetesDeploymentPublishContext(string connectStr, WorkLoad workLoad, string image)
    {
        return new KubernetesWorkLoadPublishContext(connectStr, workLoad, image);
    }
}
