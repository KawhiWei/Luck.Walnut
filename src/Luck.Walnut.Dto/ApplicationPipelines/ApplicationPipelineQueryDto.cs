using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineQueryDto:PageBaseInputDto
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