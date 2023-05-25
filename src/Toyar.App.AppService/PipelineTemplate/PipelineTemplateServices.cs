using Luck.Framework.UnitOfWorks;

using Toyar.App.Domain.Repositories;

namespace Toyar.App.AppService.PipelineTemplate
{
    /// <summary>
    /// 流水线模板
    /// </summary>
    public class PipelineTemplateServices : IPipelineTemplateServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPipelineTemplateRepository _pipelineTemplateRepository;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="pipelineTemplateRepository"></param>
        public PipelineTemplateServices(IUnitOfWork unitOfWork, IPipelineTemplateRepository pipelineTemplateRepository)
        {
            _unitOfWork = unitOfWork;
            _pipelineTemplateRepository = pipelineTemplateRepository;
        }

        public async Task CreateAsync()
        {
            await _unitOfWork.CommitAsync();
        }
    }
}
