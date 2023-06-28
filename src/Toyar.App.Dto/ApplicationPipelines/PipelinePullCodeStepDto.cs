namespace Toyar.App.Dto.ApplicationPipelines;

public class PipelinePullCodeStepDto
{
    /// <summary>
    /// 步骤名称
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// 分支
    /// </summary>
    public string Branch { get; set; }= default!;
}

public class PipelineBuildImageStepDto
{
    /// <summary>
    /// git地址
    /// </summary>
    public string BuildImageName { get; set; } = default!;

    /// <summary>
    /// 分支
    /// </summary>
    public string Version { get; set; } = default!;

    /// <summary>
    /// 分支
    /// </summary>
    public string CompileScript { get; set; } = default!;

    /// <summary>
    /// 分支
    /// </summary>
    public string DockerFileSrc { get; set; } = default!; 
}

/// <summary>
/// DockerFile发布代码和构建镜像Dto
/// </summary>
public class PipelineDockerPublishAndBuildImageStepDto
{

    /// <summary>
    /// 步骤名称
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// DockerFile路径
    /// </summary>
    public string DockerFileSrc { get; set; } = default!;

}