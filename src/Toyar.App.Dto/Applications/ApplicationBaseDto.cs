using System.ComponentModel;
using System.Net;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.Applications;

public class ApplicationBaseDto
{
    /// <summary>
    /// 应用唯一标识
    /// </summary>
    public string AppId { get; set; } = default!;

    /// <summary>
    /// 代码仓库地址
    /// </summary>
    public string GitUrl { get; set; } = default!;

}