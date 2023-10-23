namespace Toyar.App.Dto.PipelineTemplates
{
    public class PipelineTemplateOutputDto: PipelineTemplateBaseDto
    {
        public string Id { get; set; } = default!;


        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get;  set; }
    }
}
