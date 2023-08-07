using Toyar.App.Domain.AggregateRoots.K8s.Deployments;

namespace Toyar.App.Adapter.K8sAdapter.WorkLoads
{
    public interface IWorkLoadAdapter : IScopedDependency
    {
        Task DeployWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext);
    }
}
