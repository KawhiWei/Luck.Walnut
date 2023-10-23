using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;

namespace Toyar.App.Domain.AggregateRoots.K8s.Services;


/// <summary>
/// 应用部署发布基础传输上下文
/// </summary>
public class KubernetesServicePublishContext
{
    public KubernetesServicePublishContext(Service service, string configString, NameSpace nameSpace)
    {
        Service = service;

    }

    /// <summary>
    /// 
    /// </summary>
    public Service Service { get; private set; }
}

