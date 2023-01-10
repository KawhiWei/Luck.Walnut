using System.ComponentModel;
using System.Net;
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
    public string ChineseName { get; set; } = default!;

    /// <summary>
    /// 联系人
    /// </summary>
    public string Principal { get; set; } = default!;
    
    /// <summary>
    /// 应用状态
    /// </summary>
    public ApplicationStateEnum ApplicationState { get; set; }
    
    /// <summary>
    /// 应用级别
    /// </summary>
    public ApplicationLevelEnum ApplicationLevel { get; set; }

    /// <summary>
    /// 开发语言
    /// </summary>
    public string DevelopmentLanguage { get; set; } = default!;

    /// <summary>
    /// 镜像仓库地址
    /// </summary>
    public string ImageWarehouseId { get;  set; } = default!;

    /// <summary>
    /// 基础Build镜像Id
    /// </summary>
    public string BuildImageId { get;  set; } = default!;

    /// <summary>
    /// 需求描述
    /// </summary>
    public string? Describe { get; set; }
    
    /// <summary>
    /// 代码仓库地址
    /// </summary>
    public string? CodeWarehouseAddress { get; set; } = default!;
    
}