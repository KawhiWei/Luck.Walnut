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
    /// 流水线名称
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 组件集成Id
    /// </summary>
    public string BuildComponentId { get; set; } = default!;

    /// <summary>
    /// CI构建镜像
    /// </summary>
    public string ContinuousIntegrationImage { get; set; } = default!;

    /// <summary>
    /// 流水线Dsl
    /// </summary>
    public ICollection<StageDto> PipelineScript { get; set; } = default!;

}


public class ApplicationUpdatePipelineInputDto
{
    public ICollection<StageDto> PipelineScript { get; set; } = default!;
}

