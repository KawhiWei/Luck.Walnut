using Luck.Framework.Extensions;

namespace Toyar.App.Dto.K8s.WorkLoads;

public class WorkLoadOutputDto : WorkLoadBaseDto
{
    /// <summary>
    /// 
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string ClusterName { get; set; } = default!;
    
    /// <summary>
    /// 部署更新策略
    /// </summary>
    public WorkLoadPluginsDto WorkLoadPlugins { get; set; } = default!;
    
    /// <summary>
    /// 
    /// </summary>
    public List<WorkLoadContainerOutputDto> WorkLoadContainers { get; set; } = new ();

    /// <summary>
    /// 是否发布
    /// </summary>
    public bool IsPublish { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string WorkLoadTypeName => WorkLoadType.ToDescription();

    /// <summary>
    /// 
    /// </summary>
    public string ApplicationRuntimeTypeName => ApplicationRuntimeType.ToDescription();
}
