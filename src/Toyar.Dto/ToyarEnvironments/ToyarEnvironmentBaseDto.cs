namespace Toyar.Dto.ToyarEnvironments;

public abstract  class ToyarEnvironmentBaseDto
{
    /// <summary>
    /// 环境名称
    /// </summary>
    public string EnglishName { get; set; } = string.Empty;

    /// <summary>
    /// 环境中文名称
    /// </summary>
    public string ChinesName { get; set; } = string.Empty;
}