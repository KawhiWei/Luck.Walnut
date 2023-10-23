using System.Text.Json.Serialization;

namespace Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;

/// <summary>
/// 流水线自定义参数
/// </summary>
public class PipelineParameterValueObject
{
    /// <summary>
    /// 
    /// </summary>
    public PipelineParameterValueObject()
    {
    }
    
    
    [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
    public PipelineParameterValueObject(string name, string defaultValue, string description, string value)
    {
        Name = name;
        DefaultValue = defaultValue;
        Description = description;
        Value = value;
    }



    /// <summary>
    /// 参数名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 默认值
    /// </summary>
    public string DefaultValue { get; private set; }
    
    /// <summary>
    /// 参数描述
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// 参数描述
    /// </summary>
    public string Value { get; private set; }
}