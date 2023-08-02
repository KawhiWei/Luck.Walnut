using Toyar.App.Domain.AggregateRoots.K8s.Deployments;

namespace Toyar.App.Adapter.K8sAdapter.WorkLoads
{
    public interface IWorkLoadAdaper : IScopedDependency
    {
        Task CreateWorkLoadAsync(KubernetesDeploymentPublishContext kubernetesDeploymentPublishContext);
    }
}
