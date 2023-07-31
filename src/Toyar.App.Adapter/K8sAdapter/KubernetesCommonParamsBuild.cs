using k8s.Models;
using Luck.Framework.Extensions;
using Luck.Walnut.Kube.Domain.AggregateRoots.SideCar;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.AggregateRoots.ValueObjects.DeploymentValueObjects;

namespace Toyar.App.Adapter.K8sAdapter
{
    public class KubernetesCommonParamsBuild : IKubernetesCommonParamsBuild
    {

        /// <summary>
        /// 构建K8s内V1ObjectMeta对象
        /// </summary>
        /// <returns></returns>
        public V1ObjectMeta CreateV1ObjectMeta(IDictionary<string, string>? annotations = null, string? clusterName = null, System.DateTime? creationTimestamp = null, long? deletionGracePeriodSeconds = null, System.DateTime? deletionTimestamp = null, IList<string>? finalizers = null, string? generateName = null, long? generation = null, IDictionary<string, string>? labels = null, IList<V1ManagedFieldsEntry>? managedFields = null, string? name = null, string? namespaceProperty = null, IList<V1OwnerReference>? ownerReferences = null, string? resourceVersion = null, string? selfLink = null, string? uid = null)
        {

            //return new V1ObjectMeta(annotations, clusterName, creationTimestamp, deletionGracePeriodSeconds, deletionTimestamp, finalizers, generateName
            //   , generation, labels, managedFields, name, namespaceProperty, ownerReferences, resourceVersion, selfLink, uid);
            return new V1ObjectMeta();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initContainerConfiguration"></param>
        /// <returns></returns>

        public List<V1Container> CreateV1ContainerForInitContainerConfiguration(List<SideCarPlugin> initContainerConfiguration)
        {
            var v1Container = new List<V1Container>();
            return v1Container;
        }

        /// <summary>
        /// 根据主容器配置获取一个容器对象
        /// </summary>
        /// <param name="masterContainerConfiguration"></param>
        /// <returns></returns>
        public V1Container CreateV1ContainerForMasterContainerConfiguration(string containerName, DeploymentContainer deploymentContainer)
        {

            //var readinessProbe = deploymentContainer.ReadinessProbe is not null ? CreateV1Probe(masterContainerConfiguration.ReadinessProbe) : null;
            //var livenessProbe = deploymentContainer.LiveNessProbe is not null ? CreateV1Probe(masterContainerConfiguration.LiveNessProbe) : null;
            //var v1ResourceRequirements = CreateV1ResourceRequirements(masterContainerConfiguration.Limits, masterContainerConfiguration.Requests);
            var v1Container = new V1Container(
                name: containerName
                //readinessProbe: readinessProbe,
                //livenessProbe: livenessProbe,
                //resources: v1ResourceRequirements
                );
            return v1Container;


        }


        public V1PodTemplateSpec CreateV1PodTemplateSpec(V1ObjectMeta? metadata = null, V1PodSpec? spec = null)
        {
            return new V1PodTemplateSpec(metadata, spec);
        }

        /// <summary>
        /// /
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
        public V1PodSpec CreateV1PodSpec(IList<V1Container>? containers, long? activeDeadlineSeconds = null, V1Affinity? affinity = null, bool? automountServiceAccountToken = null, V1PodDNSConfig? dnsConfig = null, string? dnsPolicy = null, bool? enableServiceLinks = null, IList<V1EphemeralContainer>? ephemeralContainers = null, IList<V1HostAlias>? hostAliases = null, bool? hostIPC = null, bool? hostNetwork = null, bool? hostPID = null, string? hostname = null, IList<V1LocalObjectReference>? imagePullSecrets = null, IList<V1Container>? initContainers = null, string? nodeName = null, IDictionary<string, string>? nodeSelector = null, V1PodOS? os = null, IDictionary<string, ResourceQuantity>? overhead = null, string? preemptionPolicy = null, int? priority = null, string? priorityClassName = null, IList<V1PodReadinessGate>? readinessGates = null, string? restartPolicy = null, string? runtimeClassName = null, string? schedulerName = null, V1PodSecurityContext? securityContext = null, string? serviceAccount = null, string? serviceAccountName = null, bool? setHostnameAsFQDN = null, bool? shareProcessNamespace = null, string? subdomain = null, long? terminationGracePeriodSeconds = null, IList<V1Toleration>? tolerations = null, IList<V1TopologySpreadConstraint>? topologySpreadConstraints = null, IList<V1Volume>? volumes = null)
        {
            return new V1PodSpec(containers, activeDeadlineSeconds, affinity, automountServiceAccountToken, dnsConfig, dnsPolicy, enableServiceLinks, ephemeralContainers, hostAliases, hostIPC,
                hostNetwork, hostPID);
        }

        /// <summary>
        /// 更新策略配置
        /// </summary>
        /// <param name="maxSurge"></param>
        /// <param name="maxUnavailable"></param>
        /// <returns></returns>
        public V1RollingUpdateDeployment CreateV1RollingUpdateDeployment(int maxSurge, string maxUnavailable)
        {
            return new V1RollingUpdateDeployment(maxSurge, maxUnavailable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MatchExpressions"></param>
        /// <param name="matchLabels"></param>
        /// <returns></returns>

        public V1LabelSelector CreateV1LabelSelector(IList<V1LabelSelectorRequirement> MatchExpressions, IDictionary<string, string>? matchLabels = null)
        {
            return new V1LabelSelector(MatchExpressions, matchLabels);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerSurviveConfiguration"></param>
        /// <returns></returns>

        private V1Probe CreateV1Probe(ContainerSurviveConfiguration containerSurviveConfiguration)
        {
            return new V1Probe(periodSeconds: containerSurviveConfiguration.PeriodSeconds);
        }
        /// <summary>
        /// 创建V1ResourceRequirement
        /// </summary>
        /// <param name="limits"></param>
        /// <param name="requests"></param>
        /// <returns></returns>

        private V1ResourceRequirements CreateV1ResourceRequirements(ContainerResourceQuantity? limits, ContainerResourceQuantity? requests)
        {
            var v1ResourceRequirements = new V1ResourceRequirements();
            if (limits is not null)
            {
                Dictionary<string, ResourceQuantity> limitsDic = new Dictionary<string, ResourceQuantity>();
                if (limits.Cpu.IsNullOrWhiteSpace())
                {
                    limitsDic.Add(nameof(limits.Cpu).ToLower(), CreateResourceQuantity(limits.Cpu));
                }
                if (limits.Memory.IsNullOrWhiteSpace())
                {
                    limitsDic.Add(nameof(limits.Memory).ToLower(), CreateResourceQuantity(limits.Memory));
                }
                v1ResourceRequirements.Limits = limitsDic;
            }

            if (requests is not null)
            {
                Dictionary<string, ResourceQuantity> requestsDic = new Dictionary<string, ResourceQuantity>();
                if (requests.Cpu.IsNullOrWhiteSpace())
                {
                    requestsDic.Add(nameof(limits.Cpu).ToLower(), CreateResourceQuantity(requests.Cpu));
                }
                if (requests.Memory.IsNullOrWhiteSpace())
                {
                    requestsDic.Add(nameof(limits.Memory).ToLower(), CreateResourceQuantity(requests.Memory));
                }
                v1ResourceRequirements.Requests = requestsDic;
            }

            return v1ResourceRequirements;
        }

        /// <summary>
        /// 创建容器资源使用的数量
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private ResourceQuantity CreateResourceQuantity(string value)
        {
            return new ResourceQuantity(value);
        }


    }

}
