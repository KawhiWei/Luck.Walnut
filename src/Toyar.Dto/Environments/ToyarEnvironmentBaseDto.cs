namespace Toyar.Dto.Environments;

public class ToyarEnvironmentBaseDto
{
    /// <summary>
    /// 环境名称
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string ChinesName { get; set; } = string.Empty;
}