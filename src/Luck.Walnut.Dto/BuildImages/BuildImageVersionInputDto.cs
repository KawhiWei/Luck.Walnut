using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luck.Walnut.Dto.BuildImages;

/// <summary>
/// 镜像版本inputDto
/// </summary>
public class BuildImageVersionInputDto
{
    /// <summary>
    /// 运行镜像Id 
    /// </summary>
    public string BuildImageId { get; set; } = default!;

    /// <summary>
    /// 镜像名称
    /// </summary>
    public string Version { get; set; } = default!;
}
