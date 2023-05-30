using Luck.EntityFrameworkCore.DbContexts;
using Luck.Framework.Extensions;
using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Persistence.Repositories
{
    public class PipelineTemplateRepository : EfCoreAggregateRootRepository<PipelineTemplate, string>, IPipelineTemplateRepository
    {
        //private readonly IDictionary<string, PipelineTemplate> _pipelineTemplates;
        //private readonly IDictionary<string, PipelineTemplate> _

        public PipelineTemplateRepository(ILuckDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<(PipelineTemplate[] Data,int TotalCount)> FindPipelineTemplatePageListAsync(PipelineTemplateQueryDto query)
        {

            var queryable= FindAll()
                .WhereIf(x => x.TemplateName.Contains(query.TemplateName), !query.TemplateName.IsNullOrWhiteSpace())
            .OrderByDescending(x => x.Id); ;

            var list = await queryable.ToPage(query.PageIndex, query.PageSize).ToArrayAsync();
            var totalCount = await queryable.CountAsync();
            return (list, totalCount);
        }

        public async Task<PipelineTemplate?> FindPipelineTemplateById(string id)
        {
            return await FindAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PipelineTemplate?> FindPipelineTemplateByName(string name)
        {
            return await FindAll().FirstOrDefaultAsync(x => x.TemplateName == name);
        }


    }
}
