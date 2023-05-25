using Luck.EntityFrameworkCore.DbContexts;

using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Domain.Repositories;

namespace Toyar.App.Persistence.Repositories
{
    public class PipelineTemplateRepository : EfCoreAggregateRootRepository<PipelineTemplate, string>, IPipelineTemplateRepository
    {
        //private readonly IDictionary<string, PipelineTemplate> _pipelineTemplates;
        //private readonly IDictionary<string, PipelineTemplate> _

        public PipelineTemplateRepository(ILuckDbContext dbContext) : base(dbContext)
        {

        }

        
    }
}
