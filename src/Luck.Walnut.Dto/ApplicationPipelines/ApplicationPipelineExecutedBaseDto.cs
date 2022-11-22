using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Dto.ApplicationPipelines;

public class ApplicationPipelineExecutedBaseDto
{
    /// <summary>
    /// 流水线Id
    /// </summary>
    public string Id { get; set; } = default!;

    /// <summary>
    /// 流水线Id
    /// </summary>
    public string ApplicationPipelineId { get; set; } = default!;
    
    /// <summary>
    /// Jenkins执行Build的编号
    /// </summary>
    public uint JenkinsBuildNumber { get; set; } = default!;
    
    /// <summary>
    /// 流水线状态
    /// </summary>
    public PipelineBuildStateEnum PipelineBuildState { get;  set; }
    
    /// <summary>
    /// 镜像版本号
    /// </summary>
    public string ImageVersion { get;  set; }= default!;

    /// <summary>
    /// 执行日志
    /// </summary>
    public string? BuildLogs { get;  set; } = default!;
    
}