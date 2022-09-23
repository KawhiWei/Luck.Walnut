using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.Applications;

public class ApplicationQueryDto:PageBaseInputDto
{

    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = "";

    /// <summary>
    /// 项目id
    /// </summary>
    /// <returns></returns>
    public string ProjectId { get; set; } = "";
    
    /// <summary>
    /// 应用服务名称
    /// </summary>
    public string EnglishName { get; set; }= "";
    
    /// <summary>
    /// 应用中文名称
    /// </summary>
    public string ChinessName { get; set; }= "";
    
    /// <summary>
    /// 联系人
    /// </summary>
    public string Principal { get; set; } = "";
    
    /// <summary>
    /// 应用状态
    /// </summary>
    public ApplicationStateEnum? ApplicationState { get; set; } = default!;
    
}