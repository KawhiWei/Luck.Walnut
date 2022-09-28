namespace Luck.Walnut.Dto.Environments
{
    public class AppConfigurationOutputDto:AppConfigurationBaseOutputDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string AppEnvironmentName { get; set; }

    }
}

