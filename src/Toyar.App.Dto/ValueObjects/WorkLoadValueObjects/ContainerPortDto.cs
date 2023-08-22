namespace Toyar.App.Dto.ValueObjects.WorkLoadValueObjects;

public class ContainerPortDto
{
    /// <summary>
    /// 端口名称
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// 容器端口
    /// </summary>
    public int ContainerPort { get; set; } = default!;

    /// <summary>
    /// 端口协议
    /// </summary>
    public string Protocol { get; set; } = default!;
}