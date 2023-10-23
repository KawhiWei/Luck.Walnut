using k8s;

namespace Toyar.App.Adapter.K8sAdapter.Factories;

public interface IKubernetesClientFactory : ISingletonDependency
{
    IKubernetes GetKubernetesClient(string configString);
}