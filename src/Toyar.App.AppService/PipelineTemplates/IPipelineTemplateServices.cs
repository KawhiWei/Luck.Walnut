using Toyar.App.Dto.PipelineTemplates;

namespace Toyar.App.AppService.PipelineTemplates
{
    public interface IPipelineTemplateServices : IScopedDependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreatePipelineTemplateAsync(PipelineTemplateInputDto input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdatePipelineTemplateAsync(string id, PipelineTemplateInputDto input);

        /// <summary>
        /// 删除流水线模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePipelineTemplateAsync(string id);

    }
}
