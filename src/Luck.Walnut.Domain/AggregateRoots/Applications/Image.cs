using System.Text.Json.Serialization;

namespace Luck.Walnut.Domain.AggregateRoots.Applications
{
    /// <summary>
    /// 构建镜像信息
    /// </summary>
    public class Image
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="buildImageName"></param>
        /// <param name="compileScript"></param>
        /// <param name="version"></param>
        [JsonConstructor]//这个特性 可以写私有，标识你要用哪个构造函数
        public Image(string name, string buildImageName, string compileScript)
        {
            Name = name;
            BuildImageName = buildImageName;
            CompileScript = compileScript;
        }



        /// <summary>
        /// 镜像名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 镜像地址
        /// </summary>
        public string BuildImageName { get; private set; }
    
        /// <summary>
        /// 镜像地址
        /// </summary>
        public string CompileScript { get; private set; }
       
    }
}