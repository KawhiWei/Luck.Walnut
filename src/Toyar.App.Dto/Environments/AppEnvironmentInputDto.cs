namespace Toyar.App.Dto.Environments
{
    public class AppEnvironmentInputDto
    {

        /// <summary>
        /// 环境中文名称
        /// </summary>
        public string EnvironmentChinesName { get;  set; }= default!;
        /// <summary>
        /// 环境名称
        /// </summary>
        public string EnvironmentName { get; set; } = default!;

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; } = default!;
    }
}
