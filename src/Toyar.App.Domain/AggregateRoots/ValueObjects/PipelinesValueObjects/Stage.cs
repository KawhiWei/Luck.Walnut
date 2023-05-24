using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;

/// <summary>
/// 
/// </summary>
public class Stage
{
    public Stage()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="steps"></param>
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public Stage(string name, List<Step> steps)
    {
        Name = name;
        Steps = steps;
    }

    /// <summary>
    /// 阶段
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 步骤
    /// </summary>
    public List<Step> Steps { get; private set; }
}