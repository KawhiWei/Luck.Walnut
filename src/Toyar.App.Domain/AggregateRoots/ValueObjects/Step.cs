using System.Text.Json.Serialization;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects;

/// <summary>
/// 步骤
/// </summary>
public class Step
{
    /// <summary>
    /// 
    /// </summary>
    public Step()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="stepType"></param>
    /// <param name="content"></param>
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public Step(string name, StepTypeEnum stepType, string content)
    {
        Name = name;
        StepType = stepType;
        Content = content;
    }

    /// <summary>
    /// 步骤名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 步骤类型
    /// </summary>
    public StepTypeEnum StepType { get; private set; }

    /// <summary>
    /// 执行内容
    /// </summary>
    public string Content { get; private set; }
}