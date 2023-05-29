using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Domain.AggregateRoots.Templates
{
    public class PipelineTemplate : FullAggregateRoot
    {
        public PipelineTemplate(string templateName, string componentIntegrationId, string continuousIntegrationImageId, ICollection<Stage> pipelineScript)
        {
            TemplateName = templateName;
            ComponentIntegrationId = componentIntegrationId;
            ContinuousIntegrationImageId = continuousIntegrationImageId;
            PipelineScript = pipelineScript;
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; private set; }

        /// <summary>
        /// 流水线集成Id
        /// </summary>
        public string ComponentIntegrationId { get; private set; }

        /// <summary>
        /// CI Runner 镜像Id
        /// </summary>
        public string ContinuousIntegrationImageId { get; private set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public bool IsDefault { get; private set; }

        /// <summary>
        /// 流水线Dsl
        /// </summary>
        public ICollection<Stage> PipelineScript { get; private set; } = new HashSet<Stage>();

        public void Update(string templateName, string componentIntegrationId, string continuousIntegrationImageId, ICollection<Stage> pipelineScript)
        {
            TemplateName = templateName;
            ComponentIntegrationId = componentIntegrationId;
            ContinuousIntegrationImageId = continuousIntegrationImageId;
            PipelineScript = pipelineScript;
        }

        public void SetPipelineScript(ICollection<Stage> pipelineScript)
        {
            PipelineScript = pipelineScript;
        }

        public void CheckIsDefalut()
        {
            if(IsDefault)
            {
                throw new BusinessException($"默认流水线不允许删除！");
            }
        }

        public PipelineTemplate SetTemplateName(string templateName)
        {
            TemplateName = templateName;
            return this;
        }

        public PipelineTemplate SetComponentIntegrationId(string componentIntegrationId)
        {
            ComponentIntegrationId = componentIntegrationId;
            return this;
        }

        public PipelineTemplate SetContinuousIntegrationImageId(string continuousIntegrationImageId)
        {
            ContinuousIntegrationImageId = continuousIntegrationImageId;
            return this;
        }
    }
}
