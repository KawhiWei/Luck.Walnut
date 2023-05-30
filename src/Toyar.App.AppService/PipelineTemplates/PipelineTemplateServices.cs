using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using System.Xml.Linq;

using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.AggregateRoots.ValueObjects.PipelinesValueObjects;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.PipelineTemplates;
using Toyar.App.Persistence.Repositories;

namespace Toyar.App.AppService.PipelineTemplates
{
    /// <summary>
    /// 流水线模板
    /// </summary>
    public class PipelineTemplateServices : IPipelineTemplateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPipelineTemplateRepository _pipelineTemplateRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="pipelineTemplateRepository"></param>
        public PipelineTemplateServices(IUnitOfWork unitOfWork, IPipelineTemplateRepository pipelineTemplateRepository)
        {
            _unitOfWork = unitOfWork;
            _pipelineTemplateRepository = pipelineTemplateRepository;
        }

        public async Task CreatePipelineTemplateAsync(PipelineTemplateInputDto input)
        {
            if (await CheckAndGetPipelineTemplateByName(input.TemplateName) is not null) throw new("已存在流水线模板名称");

            var pipelineTemplate = new PipelineTemplate(input.TemplateName, input.ComponentIntegrationId, input.ContinuousIntegrationImageId)
                .SetDescribe(input.Describe ?? "")
                .SetPipelineScript(input.PipelineScript);
            _pipelineTemplateRepository.Add(pipelineTemplate);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePipelineTemplateAsync(string id, PipelineTemplateInputDto input)
        {


            var pipelineTemplate = await CheckAndGetPipelineTemplate(id);

            pipelineTemplate.SetComponentIntegrationId(input.ComponentIntegrationId).SetTemplateName(input.TemplateName).SetContinuousIntegrationImageId(input.ContinuousIntegrationImageId)
                .SetDescribe(input.Describe ?? "")
                .SetPipelineScript(input.PipelineScript);
            _pipelineTemplateRepository.Update(pipelineTemplate);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePipelineTemplateAsync(string id)
        {

            var pipelineTemplate = await CheckAndGetPipelineTemplate(id);
            pipelineTemplate.CheckIsDefalut();
            _pipelineTemplateRepository.Remove(pipelineTemplate);
            await _unitOfWork.CommitAsync();
        }

        private async Task<PipelineTemplate> CheckAndGetPipelineTemplate(string id)
        {
            var pipelineTemplate = await _pipelineTemplateRepository.FindPipelineTemplateById(id);
            return pipelineTemplate is null ? throw new BusinessException($"流水线模板不存在") : pipelineTemplate;
        }

        private async Task<PipelineTemplate?> CheckAndGetPipelineTemplateByName(string name)
        {
            var pipelineTemplate = await _pipelineTemplateRepository.FindPipelineTemplateByName(name);
            return pipelineTemplate;
        }

    }
}
