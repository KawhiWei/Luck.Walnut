using Luck.EntityFrameworkCore.DbContexts;
using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Luck.Walnut.Domain.Repositories;

namespace Luck.Walnut.Persistence.Repositories;

public class ApplicationPipelineRepository : EfCoreAggregateRootRepository<ApplicationPipeline, string>, IApplicationPipelineRepository
{
    public ApplicationPipelineRepository(ILuckDbContext dbContext) : base(dbContext)
    {
    }


    public Task<ApplicationPipeline?> FindFirstOrDefaultByIdAsync(string id)
    {
        return FindAll(x => x.Id == id).FirstOrDefaultAsync();
    }
}