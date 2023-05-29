﻿using Toyar.App.Domain.AggregateRoots.Templates;

namespace Toyar.App.Domain.Repositories;

public interface IPipelineTemplateRepository : IAggregateRootRepository<PipelineTemplate, string>, IScopedDependency
{


    /// <summary>
    /// 根据id查询一个模板
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PipelineTemplate?> FindPipelineTemplateById(string id);
}