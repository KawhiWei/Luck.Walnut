using Toyar.App.Domain.AggregateRoots.Templates;

namespace Toyar.App.Domain.Repositories;

public interface IPipelineTemplateRepository : IAggregateRootRepository<PipelineTemplate, string>, IScopedDependency
{

}
