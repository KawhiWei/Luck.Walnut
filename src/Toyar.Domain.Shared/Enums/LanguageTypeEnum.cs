using System.ComponentModel;

namespace Toyar.App.Domain.Shared.Enums;

/// <summary>
/// 语言枚举
/// </summary>
public enum LanguageTypeEnum
{
    /// <summary>
    /// DotNet
    /// </summary>
    [Description("DotNet")] DotNet = 1,

    /// <summary>
    /// Python
    /// </summary>
    [Description("Python")] Python = 2,

    /// <summary>
    /// Go
    /// </summary>
    [Description("Go")] Go = 3,

    /// <summary>
    /// Java
    /// </summary>
    [Description("Java")] Java = 4,

    /// <summary>
    /// NodeJs
    /// </summary>
    [Description("NodeJs")] NodeJs = 5,
}