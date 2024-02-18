namespace Toyar.App.Domain.Shared.Enums;

/// <summary>
/// 镜像仓库类型
/// </summary>
public enum RegistryTypeEnum
{
    /// <summary>
    /// 无镜像仓库
    /// </summary>
    None = 0,

    /// <summary>
    /// 阿里云镜像仓库
    /// </summary>
    AliCloudRegistry = 1,

    /// <summary>
    /// 腾讯云镜像仓库
    /// </summary>
    TencentCloudRegistry = 2,

    /// <summary>
    /// Harbor
    /// </summary>
    HarborRegistry = 3,
}