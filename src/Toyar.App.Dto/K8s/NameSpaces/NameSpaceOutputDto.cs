using Luck.Framework.Extensions;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.K8s.NameSpaces;

public class NameSpaceOutputDto : NameSpaceBaseDto
{
    /// <summary>
    /// 归属集群
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// 归属集群
    /// </summary>
    public string ClusterName { get; set; } = default!;


    /// <summary>
    /// 
    /// </summary>
    public OnlineStatusEnum OnlineStatus { get; set; }

    /// <summary>
    /// 归属集群
    /// </summary>
    //public string OnlineStatusName => OnlineStatus.GetDescription();
}