using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;

namespace Toyar.App.Adapter.K8sAdapter.NameSpaces
{
    public interface INameSpaceAdaper : IScopedDependency
    {
        /// <summary>
        /// 创建NameSpace
        /// </summary>
        /// <param name="kubernetes"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        Task CreateNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext);

        /// <summary>
        /// 删除NameSpace
        /// </summary>
        /// <param name="kubernetes"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task DeleteNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext);

        /// <summary>
        /// 修改NameSpace
        /// </summary>
        /// <param name="kubernetes"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        Task UpdateNameSpaceAsync(KubernetesNameSpacePublishContext kubernetesNameSpacePublishContext);
    }
}
