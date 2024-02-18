using System.Text;
using k8s;

namespace Toyar.App.Adapter.K8sAdapter.Factories;

public class KubernetesClientFactory : IKubernetesClientFactory
{
    public IKubernetes GetKubernetesClient(string configString)
    {
        byte[] array = Encoding.ASCII.GetBytes(configString);
        using var stream = new MemoryStream(array);
        var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(stream);
        return new Kubernetes(config);
    }
}