using Luck.Walnut.Domain.AggregateRoots.ApplicationPipelines;
using Microsoft.EntityFrameworkCore;

namespace Luck.Walnut.Domain.Repositories;

public interface IApplicationPipelineRepository : IAggregateRootRepository<ApplicationPipeline, string>, IScopedDependency
{
    Task<ApplicationPipeline?> FindFirstOrDefaultByIdAsync(string id);

}