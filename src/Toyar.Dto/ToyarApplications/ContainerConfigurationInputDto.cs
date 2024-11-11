namespace Toyar.Dto.ToyarApplications;

public class ContainerConfigurationInputDto
{
    /// <summary>
    /// 容器模式
    /// </summary>
    public string ContainerPattern { get; set; } = string.Empty;

    /// <summary>
    /// 内存
    /// </summary>
    public string MemorySizeMaxMib { get; set; } = string.Empty;

    /// <summary>
    /// Cpu核心
    /// </summary>
    public string Cpu { get; set; } = string.Empty;
}