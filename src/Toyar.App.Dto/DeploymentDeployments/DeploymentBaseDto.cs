﻿using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Dto.Deployments;

public class DeploymentBaseDto
{


    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; set; } = default!;


    /// <summary>
    /// 中文名称
    /// </summary>
    public string ChineseName { get; set; } = default!;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = default!;


    /// <summary>
    /// 部署环境
    /// </summary>
    public string EnvironmentName { get; set; } = default!;

    /// <summary>
    /// 应用运行时类型
    /// </summary>
    public ApplicationRuntimeTypeEnum ApplicationRuntimeType { get; set; }

    /// <summary>
    /// 部署类型
    /// </summary>
    public DeploymentTypeEnum DeploymentType { get; set; }



    /// <summary>
    /// 应用Id
    /// </summary>
    public string ClusterId { get; set; } = default!;

    /// <summary>
    /// 命名空间Id
    /// </summary>
    public string NameSpace { get; set; } = default!;

    /// <summary>
    /// 部署副本数量
    /// </summary>
    public int Replicas { get; set; }

    /// <summary>
    /// 镜像拉取证书
    /// </summary>
    public string? ImagePullSecretId { get; set; }

    /// <summary>
    /// 部署更新策略
    /// </summary>
    public StrategyInputDto? Strategy { get; set; }

    /// <summary>
    /// 初始容器配置列表
    /// </summary>
    public List<string> SideCarPlugins { get; set; } = new List<string>();
}
