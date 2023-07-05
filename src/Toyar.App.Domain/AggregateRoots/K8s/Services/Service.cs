using Luck.Framework.Exceptions;
using Toyar.App.Dto.K8s.Services;

namespace Toyar.App.Domain.AggregateRoots.K8s.Services;

/// <summary>
/// 服务配置
/// </summary>
public partial class Service : FullAggregateRoot
{
    public Service(string name, string deploymentId, string nameSpaceId, string clusterId, string appId, bool isPublish = false)
    {
        Name = name;
        DeploymentId = deploymentId;
        NameSpaceId = nameSpaceId;
        ClusterId = clusterId;
        AppId = appId;
        IsPublish = isPublish;
    }

    /// <summary>
    /// 服务名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; private set; }

    /// <summary>
    /// 部署配置Id
    /// </summary>
    public string DeploymentId { get; private set; }

    /// <summary>
    /// 命名空间Id
    /// </summary>
    public string NameSpaceId { get; private set; }

    /// <summary>
    /// 命名空间Id
    /// </summary>
    public string ClusterId { get; private set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool IsPublish { get; private set; } = default!;

    /// <summary>
    /// 服务端口配置
    /// </summary>
    public ICollection<ServicePort> ServicePorts { get; private set; } = new HashSet<ServicePort>();


    public void RemoveCheck()
    {
        if (IsPublish)
        {
            throw new BusinessException($"【{Name}】在发布状态下不允许删除，请先下线");
        }
    }

    public Service Update(string name, string deploymentId, string nameSpaceId, string clusterId)
    {
        Name = name;
        DeploymentId = deploymentId;
        NameSpaceId = nameSpaceId;
        ClusterId = clusterId;
        return this;
    }
    public Service SetIsPublish(bool isPublish)
    {
        IsPublish = isPublish;
        return this;
    }

    public Service SetServicePorts(ServiceInputDto input)
    {
        if (input.ServicePorts is null)
        {
            return this;
        }

        foreach (var servicePortInput in input.ServicePorts)
        {
            ServicePorts.Add(new ServicePort(servicePortInput.PortType, servicePortInput.PortName, servicePortInput.SourcePort, servicePortInput.TargetPort));
        }

        return this;
    }

}