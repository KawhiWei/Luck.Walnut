using Luck.Framework.Exceptions;

using Toyar.App.Domain.AggregateRoots.ValueObject.DeploymentValueObjects;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.DeploymentConfigurations;

namespace Toyar.App.Domain.AggregateRoots.DeploymentConfiguration;

public class DeploymentConfiguration : FullAggregateRoot
{
    public DeploymentConfiguration(string environmentName, ApplicationRuntimeTypeEnum applicationRuntimeType, DeploymentTypeEnum deploymentType, string chineseName, string name, string appId,
        string nameSpaceId, int replicas, string? imagePullSecretId, string clusterId, bool isPublish = false)
    {
        EnvironmentName = environmentName;
        ApplicationRuntimeType = applicationRuntimeType;
        DeploymentType = deploymentType;
        ChineseName = chineseName;
        Name = name;
        AppId = appId;
        NameSpaceId = nameSpaceId;
        Replicas = replicas;
        ImagePullSecretId = imagePullSecretId;
        ClusterId = clusterId;
        IsPublish = isPublish;
    }

    /// <summary>
    /// 部署环境
    /// </summary>
    public string EnvironmentName { get; private set; }

    /// <summary>
    /// 应用运行时类型
    /// </summary>
    public ApplicationRuntimeTypeEnum ApplicationRuntimeType { get; private set; }

    /// <summary>
    /// 部署类型
    /// </summary>
    public DeploymentTypeEnum DeploymentType { get; private set; }

    /// <summary>
    /// 中文名称
    /// </summary>
    public string ChineseName { get; private set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string ClusterId { get; private set; }

    /// <summary>
    /// 命名空间Id
    /// </summary>
    public string NameSpaceId { get; private set; }

    /// <summary>
    /// 部署副本数量
    /// </summary>
    public int Replicas { get; private set; }

    /// <summary>
    /// 镜像拉取证书
    /// </summary>
    public string? ImagePullSecretId { get; private set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool IsPublish { get; private set; }

    /// <summary>
    /// 更新策略
    /// </summary>
    public Strategy? Strategy { get; private set; } = null;

    /// <summary>
    /// 主应用容器配置
    /// </summary>
    public ICollection<MasterContainerConfiguration> MasterContainers { get; private set; } = new HashSet<MasterContainerConfiguration>();

    /// <summary>
    /// 初始容器配置列表
    /// </summary>
    public ICollection<string> SideCarPlugins { get; private set; } = new HashSet<string>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public DeploymentConfiguration SetDeploymentInfo(DeploymentConfigurationInputDto input)
    {
        EnvironmentName = input.EnvironmentName;
        ApplicationRuntimeType = input.ApplicationRuntimeType;
        DeploymentType = input.DeploymentType;
        ChineseName = input.ChineseName;
        AppId = input.AppId;
        NameSpaceId = input.NameSpaceId;
        Replicas = input.Replicas;
        ImagePullSecretId = input.ImagePullSecretId;
        Name = input.Name;
        ClusterId = input.ClusterId;
        NameSpaceId = input.NameSpaceId;
        SetInitContainers(input.SideCarPlugins);
        return this;
    }


    public DeploymentConfiguration SetStrategy(StrategyInputDto? input)
    {
        if (input is not null)
        {
            Strategy = new Strategy(input.Type, input.MaxSurge, input.MaxUnavailable);
        }
        return this;

    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DeploymentConfiguration SetInitContainers(List<string>? sideCarPlugins)
    {
        if (sideCarPlugins is null)
        {
            return this;
        }

        SideCarPlugins = sideCarPlugins;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationContainerId"></param>
    /// <returns></returns>
    public DeploymentConfiguration RemoveDeploymentContainerConfiguration(string applicationContainerId)
    {
        var applicationContainer = MasterContainers.FirstOrDefault(x => x.Id == applicationContainerId);
        if (applicationContainer is null)
        {
            throw new BusinessException($"容器配置不存在，请刷新页面");
        }

        MasterContainers.Remove(applicationContainer);
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public DeploymentConfiguration AddMasterContainerConfiguration(MasterContainerConfigurationInputDto input)
    {
        if (CheckApplicationContainerName(input.ContainerName))
        {
            throw new BusinessException($"【{input.ContainerName}】已存在");
        }

        var applicationContainer = new MasterContainerConfiguration(input.ContainerName,
            input.RestartPolicy, input.ImagePullPolicy, input.IsInitContainer, input.Image ?? "");

        applicationContainer
            .SetLimits(input.Limits)
            .SetRequests(input.Requests)
            .SetLiveNessProbe(input.LiveNessProbe)
            .SetReadinessProbe(input.ReadinessProbe)
            .SetEnvironments(input.Environments);

        MasterContainers.Add(applicationContainer);

        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="containerName"></param>
    /// <param name="currentId"></param>
    /// <param name="isUpdate"></param>
    /// <returns></returns>
    private bool CheckApplicationContainerName(string containerName, string currentId = "", bool isUpdate = false)
    {
        if (isUpdate)
        {
            return MasterContainers.Any(x => x.ContainerName == containerName && x.Id != currentId);
        }

        return MasterContainers.Any(x => x.ContainerName == containerName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationContainerId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public DeploymentConfiguration UpdateMasterContainerConfiguration(string applicationContainerId, MasterContainerConfigurationInputDto input)
    {
        var applicationContainer = MasterContainers.FirstOrDefault(x => x.Id == applicationContainerId);
        if (applicationContainer is null)
        {
            throw new BusinessException($"容器配置不存在，请刷新页面");
        }

        if (CheckApplicationContainerName(input.ContainerName, applicationContainerId, true))
        {
            throw new BusinessException($"【{input.ContainerName}】已存在");
        }

        applicationContainer
            .Update(input)
            .SetLimits(input.Limits)
            .SetRequests(input.Requests)
            .SetLiveNessProbe(input.LiveNessProbe)
            .SetReadinessProbe(input.ReadinessProbe)
            .SetEnvironments(input.Environments);
        return this;
    }
}
