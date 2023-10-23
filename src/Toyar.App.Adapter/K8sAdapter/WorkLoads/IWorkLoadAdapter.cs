using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;

namespace Toyar.App.Adapter.K8sAdapter.WorkLoads
{
    public interface IWorkLoadAdapter : IScopedDependency
    {
        Task DeployWorkLoadAsync(KubernetesWorkLoadPublishContext kubernetesWorkLoadPublishContext);
    }
}
