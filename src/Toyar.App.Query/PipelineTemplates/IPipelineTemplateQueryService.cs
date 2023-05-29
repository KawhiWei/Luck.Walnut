using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toyar.App.Dto.ApplicationPipelines;
using Toyar.App.Dto;
using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.Query.PipelineTemplates
{
    public interface IPipelineTemplateQueryService : IScopedDependency
    {
        /// <summary>
        /// 分页获取流水线列表
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PageBaseResult<PipelineOutputDto>> GetPipelineTemplatePageListAsync(PipelineTemplateQueryDto query);

    }
}
