using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.Applications;

public class ApplicationQueryDto:PageBaseInputDto
{

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = "";
    
    
}