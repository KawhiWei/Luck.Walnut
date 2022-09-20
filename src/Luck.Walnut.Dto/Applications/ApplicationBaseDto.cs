using System.ComponentModel;
using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.Applications;

public class ApplicationBaseDto
{
    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = default!;

    /// <summary>
    /// 项目id
    /// </summary>
    /// <returns></returns>
    public string ProjectId { get;  set; }= default!;

    /// <summary>
    /// 应用服务名称
    /// </summary>
    public string EnglishName { get; set; } = default!;

    /// <summary>
    /// 应用所属部门
    /// </summary>
    public string DepartmentName { get; set; } = default!;

    /// <summary>
    /// 应用中文名称
    /// </summary>
    public string ChinessName { get; set; } = default!;

    /// <summary>
    /// 联系人
    /// </summary>
    public string Principal { get; set; } = default!;

    /// <summary>
    /// 应用描述
    /// </summary>
    /// <returns></returns>
    public string Description { get; set; } = default!;

    /// <summary>
    /// 应用状态
    /// </summary>
    public ApplicationStatusEnum ApplicationStatus { get; set; } = default!;
}