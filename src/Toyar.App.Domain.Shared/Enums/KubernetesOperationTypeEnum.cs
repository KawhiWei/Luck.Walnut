using System.ComponentModel;

namespace Toyar.App.Domain.Shared.Enums;

/// <summary>
/// kubernetes类型枚举
/// </summary>
public enum  KubernetesOperationTypeEnum{

    /// <summary>
    /// WorkLoads
    /// </summary>
    [Description("WorkLoads")]
    WorkLoads=1,
    
    /// <summary>
    /// NetWork
    /// </summary>
    [Description("NetWork")]
    NetWork=2,
    
    /// <summary>
    /// NameSpace
    /// </summary>
    [Description("NameSpace")]
    NameSpace=3,

}