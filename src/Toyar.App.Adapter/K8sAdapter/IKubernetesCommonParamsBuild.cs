using k8s.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toyar.App.Domain.AggregateRoots.Deployments;

namespace Toyar.App.Adapter.K8sAdapter
{
    internal interface IKubernetesCommonParamsBuild
    {
        /// <summary>
        /// 构建V1ObjectMeta对象
        /// </summary>
        /// <returns></returns>
        V1ObjectMeta CreateV1ObjectMeta(IDictionary<string, string>? annotations = null, string? clusterName = null, System.DateTime? creationTimestamp = null, long? deletionGracePeriodSeconds = null, System.DateTime? deletionTimestamp = null, IList<string>? finalizers = null, string? generateName = null, long? generation = null, IDictionary<string, string>? labels = null, IList<V1ManagedFieldsEntry>? managedFields = null, string? name = null, string? namespaceProperty = null, IList<V1OwnerReference>? ownerReferences = null, string? resourceVersion = null, string? selfLink = null, string? uid = null);



        /// <summary>
        /// 根据主容器配置获取一个容器对象
        /// </summary>
        /// <param name="masterContainerConfiguration"></param>
        /// <returns></returns>
        V1Container CreateV1ContainerForMasterContainerConfiguration(string containerName, DeploymentContainer deploymentContainer);



        /// <summary>
        /// /创建Pod模板规格
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        V1PodTemplateSpec CreateV1PodTemplateSpec(V1ObjectMeta? metadata, V1PodSpec? spec);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="containers"></param>
        /// <param name="activeDeadlineSeconds"></param>
        /// <param name="affinity"></param>
        /// <param name="automountServiceAccountToken"></param>
        /// <param name="dnsConfig"></param>
        /// <param name="dnsPolicy"></param>
        /// <param name="enableServiceLinks"></param>
        /// <param name="ephemeralContainers"></param>
        /// <param name="hostAliases"></param>
        /// <param name="hostIPC"></param>
        /// <param name="hostNetwork"></param>
        /// <param name="hostPID"></param>
        /// <param name="hostname"></param>
        /// <param name="imagePullSecrets"></param>
        /// <param name="initContainers"></param>
        /// <param name="nodeName"></param>
        /// <param name="nodeSelector"></param>
        /// <param name="os"></param>
        /// <param name="overhead"></param>
        /// <param name="preemptionPolicy"></param>
        /// <param name="priority"></param>
        /// <param name="priorityClassName"></param>
        /// <param name="readinessGates"></param>
        /// <param name="restartPolicy"></param>
        /// <param name="runtimeClassName"></param>
        /// <param name="schedulerName"></param>
        /// <param name="securityContext"></param>
        /// <param name="serviceAccount"></param>
        /// <param name="serviceAccountName"></param>
        /// <param name="setHostnameAsFQDN"></param>
        /// <param name="shareProcessNamespace"></param>
        /// <param name="subdomain"></param>
        /// <param name="terminationGracePeriodSeconds"></param>
        /// <param name="tolerations"></param>
        /// <param name="topologySpreadConstraints"></param>
        /// <param name="volumes"></param>
        /// <returns></returns>
        V1PodSpec CreateV1PodSpec(IList<V1Container>? containers, long? activeDeadlineSeconds = null, V1Affinity? affinity = null, bool? automountServiceAccountToken = null, V1PodDNSConfig? dnsConfig = null, string? dnsPolicy = null, bool? enableServiceLinks = null, IList<V1EphemeralContainer>? ephemeralContainers = null, IList<V1HostAlias>? hostAliases = null, bool? hostIPC = null, bool? hostNetwork = null, bool? hostPID = null, string? hostname = null, IList<V1LocalObjectReference>? imagePullSecrets = null, IList<V1Container>? initContainers = null, string? nodeName = null, IDictionary<string, string>? nodeSelector = null, V1PodOS? os = null, IDictionary<string, ResourceQuantity>? overhead = null, string? preemptionPolicy = null, int? priority = null, string? priorityClassName = null, IList<V1PodReadinessGate>? readinessGates = null, string? restartPolicy = null, string? runtimeClassName = null, string? schedulerName = null, V1PodSecurityContext? securityContext = null, string? serviceAccount = null, string? serviceAccountName = null, bool? setHostnameAsFQDN = null, bool? shareProcessNamespace = null, string? subdomain = null, long? terminationGracePeriodSeconds = null, IList<V1Toleration>? tolerations = null, IList<V1TopologySpreadConstraint>? topologySpreadConstraints = null, IList<V1Volume>? volumes = null);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="MatchExpressions"></param>
        /// <param name="matchLabels"></param>
        /// <returns></returns>
        V1LabelSelector CreateV1LabelSelector(IList<V1LabelSelectorRequirement> MatchExpressions, IDictionary<string, string>? matchLabels = null);

        /// <summary>
        /// 创建更新策略
        /// </summary>
        /// <param name="maxSurge"></param>
        /// <param name="maxUnavailable"></param>
        /// <returns></returns>
        V1RollingUpdateDeployment CreateV1RollingUpdateDeployment(int maxSurge, string maxUnavailable);
    }

}
