using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.ApplicationPipelines;

public class PipelineQueryDto:PageBaseInputDto
{

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// 是否发布
    /// </summary>
    public bool? Published  { get; set; }= default!;
}