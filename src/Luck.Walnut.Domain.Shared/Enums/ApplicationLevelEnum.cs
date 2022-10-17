using System.ComponentModel;
using System.Security.Cryptography;

namespace Luck.Walnut.Domain.Shared.Enums;

/// <summary>
/// 应用保障P
/// </summary>
public enum ApplicationLevelEnum
{
    /// <summary>
    /// P0
    /// </summary>
    [Description("P0")] LevelZero = 0,

    /// <summary>
    /// P1
    /// </summary>
    [Description("P1")] LevelOne = 1,

    /// <summary>
    /// P2
    /// </summary>
    [Description("P2")] LevelTwo = 2,

    /// <summary>
    /// P3
    /// </summary>
    [Description("P3")] LevelThree = 3,

    /// <summary>
    /// P4
    /// </summary>
    [Description("P4")] LevelFour = 4,

    /// <summary>
    /// P5
    /// </summary>
    [Description("P5")] LevelFive = 5,

    /// <summary>
    /// P6
    /// </summary>
    [Description("P6")] LevelSix = 6,
}