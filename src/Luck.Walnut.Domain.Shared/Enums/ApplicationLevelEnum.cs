using System.ComponentModel;
using System.Security.Cryptography;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 应用保障级别
/// </summary>
public enum ApplicationLevelEnum
{
    /// <summary>
    /// 级别0
    /// </summary>
    [Description("级别0")] LevelZero = 0,

    /// <summary>
    /// 级别1
    /// </summary>
    [Description("级别1")] LevelOne = 1,

    /// <summary>
    /// 级别2
    /// </summary>
    [Description("级别2")] LevelTwo = 2,

    /// <summary>
    /// 级别3
    /// </summary>
    [Description("级别3")] LevelThree = 3,

    /// <summary>
    /// 级别4
    /// </summary>
    [Description("级别4")] LevelFour = 4,

    /// <summary>
    /// 级别5
    /// </summary>
    [Description("级别5")] LevelFive = 5,

    /// <summary>
    /// 级别6
    /// </summary>
    [Description("级别6")] LevelSix = 6,
}