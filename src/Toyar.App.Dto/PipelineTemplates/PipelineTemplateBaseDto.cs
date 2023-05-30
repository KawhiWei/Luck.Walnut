using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Dto.PipelineTemplates
{
    public class PipelineTemplateBaseDto
    {

        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get;  set; }

        /// <summary>
        /// 流水线集成Id
        /// </summary>
        public string ComponentIntegrationId { get; set; } = default!;

        /// <summary>
        /// CI Runner 镜像Id
        /// </summary>
        public string ContinuousIntegrationImageId { get; set; } = default!;

        /// <summary>
        /// 应用描述
        /// </summary>
        public string? Describe { get;  set; }

        /// <summary>
        /// 流水线Dsl
        /// </summary>
        public ICollection<StageDto>? PipelineScript { get;  set; }
    }
}
