using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toyar.App.Domain.Shared.Enums;

namespace Toyar.App.Domain.AggregateRoots.KubernetesOperationHistories
{
    /// <summary>
    /// 
    /// </summary>
    public class KubernetesOperationHistory:FullAggregateRoot
    {
        public KubernetesOperationHistory(string appId, string configJson, string createUser, KubernetesOperationTypeEnum kubernetesOperationType)
        {
            AppId = appId;
            ConfigJson = configJson;
            CreateUser = createUser;
            KubernetesOperationType = kubernetesOperationType;
        }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; private set; }
        
        /// <summary>
        /// 记录操作内容
        /// </summary>
        public string ConfigJson { get; private set; }
        
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; private set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public KubernetesOperationTypeEnum KubernetesOperationType { get; private set; }
    }
}
