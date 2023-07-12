namespace Toyar.App.Dto.DeploymentConfigurations;

public class StrategyInputDto
{

    /// <summary>
    /// 策略类型
    /// </summary>
    public string Type { get; set; } = default!;

    /// <summary>
    /// 可调度的最大吊舱数量超过所需吊舱数量
    /// </summary>
    public string MaxSurge { get; set; } = default!;

    /// <summary>
    /// 更新期间不可用的最大pod数
    /// </summary>
    public string MaxUnavailable { get; set; } = default!;
}

