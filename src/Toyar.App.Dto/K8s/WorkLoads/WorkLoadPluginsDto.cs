namespace Toyar.App.Dto.K8s.WorkLoads;

public class WorkLoadPluginsDto
{
    /// <summary>
    /// 策略类型
    /// </summary>
    public StrategyBaseDto Strategy { get; set; } = default!;
}