using Luck.Framework.Exceptions;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.K8s.NameSpaces;

namespace Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;

/// <summary>
/// 命名空间
/// </summary>
public class NameSpace : FullAggregateRoot
{
    public NameSpace(string chineseName, string name, string clusterId, OnlineStatusEnum onlineStatus = OnlineStatusEnum.Offline)
    {
        ChineseName = chineseName;
        Name = name;
        OnlineStatus = onlineStatus;
        ClusterId = clusterId;
    }

    /// <summary>
    /// 中文名称
    /// </summary>
    public string ChineseName { get; private set; }

    /// <summary>
    /// 明明空间名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 集群Id
    /// </summary>
    public string ClusterId { get; private set; }

    /// <summary>
    /// 是否发布
    /// </summary>
    public OnlineStatusEnum OnlineStatus { get; private set; }

    public NameSpace Update(NameSpaceInputDto input)
    {
        ChineseName = input.ChineseName;
        Name = input.Name;
        ClusterId = input.ClusterId;
        return this;
    }

    public NameSpace SetOnline(OnlineStatusEnum onlineStatus)
    {
        OnlineStatus = onlineStatus;
        return this;
    }

    public void CheckOnlineStatusIsOnline()
    {
        if (OnlineStatus == OnlineStatusEnum.Online)
        {
            throw new BusinessException("已上线的NameSpace不允许修改！");
        }
    }
}