using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luck.Walnut.Kube.Domain.AggregateRoots.SideCarPlugins
{
   public class SideCarPluginVersion:FullEntity
   {
        public SideCarPluginVersion(string sideCarPluginId, string version, SideCarPlugin sideCarPlugin)
        {
            SideCarPluginId = sideCarPluginId;
            Version = version;
            SideCarPlugin = sideCarPlugin;
        }


        /// <summary>
        /// 运行镜像Id 
        /// </summary>
        public string SideCarPluginId { get; private set; }

        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SideCarPlugin SideCarPlugin { get; } = default!;
   }
}
