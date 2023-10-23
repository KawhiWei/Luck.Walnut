namespace Toyar.App.Dto.Environments
{
    public class AppConfigurationOutputDto:AppConfigurationBaseOutputDto
    {
        public string Id { get; set; } = default!;

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; } = default!;
        
        /// <summary>
        /// 
        /// </summary>
        public string AppEnvironmentName { get; set; } = default!;

    }
}

