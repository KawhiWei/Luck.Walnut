using Luck.Framework.Extensions;

namespace Luck.Walnut.Dto.Applications
{
    public class ApplicationOutputDto : ApplicationBaseDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = default!;

        /// <summary>
        /// 应用状态
        /// </summary>
        public string ApplicationStateName => ApplicationState.ToDescription();
        
        /// <summary>
        /// 构建脚本
        /// </summary>
        public string CompileScript  { get; set; } = default!;
        
        /// <summary>
        /// 镜像名称
        /// </summary>
        public string BuildImageName  { get; set; } = default!;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; } = default!;
    }
}