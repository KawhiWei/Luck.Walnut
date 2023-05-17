using Toyar.App.Dto.ContinuousIntegrationImages;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Dto.Applications
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
        
        public List<ContinuousIntegrationImageVersionOutputDto> BuildImageVersionList { get; set; } = default!;

        


    }
}
