namespace Toyar.Dto.ToyarApps;

public class ToyarApplicationInputDto : ToyarApplicationBaseDto
{
    /// <summary>
    /// 环境Id列表
    /// </summary>
    public List<string> EnvironmentIdList { get; set; } = new();
}