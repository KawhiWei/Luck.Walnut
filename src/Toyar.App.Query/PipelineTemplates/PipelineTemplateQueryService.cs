using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Query.PipelineTemplates
{
    public class PipelineTemplateQueryService : IPipelineTemplateQueryService
    {
        private readonly IPipelineTemplateRepository _pipelineTemplateRepository;

        public PipelineTemplateQueryService(IPipelineTemplateRepository pipelineTemplateRepository)
        {
            _pipelineTemplateRepository = pipelineTemplateRepository;
        }

        public async Task<PageBaseResult<PipelineOutputDto>> GetPipelineTemplatePageListAsync(PipelineTemplateQueryDto query)
        {

            throw new NotImplementedException();
        }

        public async Task<PipelineTemplateOutputDto?> GetPipelineTemplateFirstOrDefaultById(string id)
        {
            var pipelineTemplate = await _pipelineTemplateRepository.FindPipelineTemplateById(id);
            return pipelineTemplate is null ? null : GetPipelineTemplateOutputDto(pipelineTemplate);
        }

        private PipelineTemplateOutputDto GetPipelineTemplateOutputDto(PipelineTemplate pipelineTemplate)
        {
            return new PipelineTemplateOutputDto
            {
                ComponentIntegrationId = pipelineTemplate.ComponentIntegrationId,
                ContinuousIntegrationImageId = pipelineTemplate.ContinuousIntegrationImageId,
                Id = pipelineTemplate.Id,
            };
        }
    }
}
