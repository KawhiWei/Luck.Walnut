namespace Toyar.App.Domain.AggregateRoots.K8s.NameSpaces
{
    public class KubernetesNameSpacePublishContext : KubernetesPublishBaseContext
    {
        public KubernetesNameSpacePublishContext(string configString, NameSpace nameSpace) : base(configString)
        {
            NameSpace = nameSpace;
        }


        /// <summary>
        /// 
        /// </summary>
        public NameSpace NameSpace { get; private set; } = default!;
    }
}
