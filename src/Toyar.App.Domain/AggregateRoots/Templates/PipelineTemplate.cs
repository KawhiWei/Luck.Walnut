using Luck.Framework.Exceptions;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Dto.ValueObjects.PipelinesValueObjects;

namespace Toyar.App.Domain.AggregateRoots.Templates
{
    public class PipelineTemplate : FullAggregateRoot
    {
        public PipelineTemplate(string templateName, string componentIntegrationId, string continuousIntegrationImageId)
        {
            TemplateName = templateName;
            ComponentIntegrationId = componentIntegrationId;
            ContinuousIntegrationImageId = continuousIntegrationImageId;
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
        /// 应用描述
        /// </summary>
        public string? Describe { get; private set; }
        
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; private set; } = default!;
        
        /// <summary>
        /// 最近修改人
        /// </summary>
        public string LastModificationUser { get; private set; } = default!;

        /// <summary>
        /// 流水线Dsl
        /// </summary>
        public ICollection<Stage>? PipelineScript { get; private set; } = new HashSet<Stage>();

        public PipelineTemplate SetPipelineScript(ICollection<StageDto>? pipelineScript)
        {
            if (pipelineScript is null)
            {
                PipelineScript = new HashSet<Stage>();
            }
            else
            {
                PipelineScript = pipelineScript
                    .Select(p => new Stage(p.Name, p.Steps.Select(x => new Step(x.Name, x.StepType, x.Content)
                    ).
                    ToList())).ToList();
            }
            return this;
        }

        public void CheckIsDefalut()
        {
            if (IsDefault)
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

        public PipelineTemplate SetDescribe(string describe)
        {
            Describe = describe;
            return this;
        }
    }
}
