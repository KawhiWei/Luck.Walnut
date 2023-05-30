using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto.Applications;
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

        public async Task<PageBaseResult<PipelineTemplateOutputDto>> GetPipelineTemplatePageListAsync(PipelineTemplateQueryDto query)
        {
var result= await            _pipelineTemplateRepository.FindPipelineTemplatePageListAsync(query);

            var list=result.Data.Select(x => GetPipelineTemplateOutputDto(x)).ToArray();
            return new PageBaseResult<PipelineTemplateOutputDto>(result.TotalCount, list);
        }

        public async Task<PipelineTemplateOutputDto?> GetPipelineTemplateByIdFirstOrDefaultAsync(string id)
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
                TemplateName = pipelineTemplate.TemplateName,
                IsDefault = pipelineTemplate.IsDefault,
            };
        }
    }
}
