namespace Luck.Walnut.Dto.Jenkinses;

public class JenkinsJobDetailDto
{
    public uint NextBuildNumber { get;  set; }

    /// <summary>
    /// 运行结果
    /// </summary>
    public string Result { get; set; } = default!;
}