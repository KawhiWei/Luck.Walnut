using Luck.Walnut.Dto.BuildImages;
using Luck.Walnut.Dto.Environments;

namespace Luck.Walnut.Dto.Applications
{
    public class ApplicationOutput
    {
        /// <summary>
        /// 应用描述
        /// </summary>
        public ApplicationOutputDto Application { get; set; }=default!;

        /// <summary>
        /// 环境列表
        /// </summary>
        public List<AppEnvironmentListOutputDto> EnvironmentList { get; set; } = default!;
        
        public List<BuildImageVersionOutputDto> BuildImageVersionList { get; set; } = default!;
        
        
    }
}
