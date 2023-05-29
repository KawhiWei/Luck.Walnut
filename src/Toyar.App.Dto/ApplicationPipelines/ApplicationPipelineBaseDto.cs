using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Dto.ApplicationPipelines;

public class ApplicationPipelineBaseDto
{
    /// <summary>
    /// 
    /// </summary>
    public string AppId { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string AppEnvironmentId { get; set; } = default!;

    /// <summary>
    /// 组件集成Id
    /// </summary>
    public string ComponentIntegrationId { get; set; } = default!;

    /// <summary>
    /// 代码仓库地址
    /// </summary>
    public string? CodeWarehouseAddress { get; set; }

    /// <summary>
    /// 流水线名称
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<StageDto> PipelineScript { get; set; } = default!;

    /// <summary>
    /// 下一流水线Id
    /// </summary>
    public string? NextPipelineId { get; set; }
}