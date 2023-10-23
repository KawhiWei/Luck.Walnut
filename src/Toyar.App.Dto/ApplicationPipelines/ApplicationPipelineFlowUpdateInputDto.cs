using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Dto.ApplicationPipelines;

public class ApplicationPipelineFlowUpdateInputDto
{
    public ICollection<StageDto> PipelineScript { get; set; } = default!;
}

