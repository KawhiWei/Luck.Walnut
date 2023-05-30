using Toyar.App.Domain.AggregateRoots.Templates;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Domain.Repositories;

public interface IPipelineTemplateRepository : IAggregateRootRepository<PipelineTemplate, string>, IScopedDependency
{

    Task<(PipelineTemplate[] Data, int TotalCount)> FindPipelineTemplatePageListAsync(PipelineTemplateQueryDto query);

    /// <summary>
    /// 根据id查询一个模板
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PipelineTemplate?> FindPipelineTemplateById(string id);

    /// <summary>
    /// 根据name查询一个模板
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<PipelineTemplate?> FindPipelineTemplateByName(string name);
}
