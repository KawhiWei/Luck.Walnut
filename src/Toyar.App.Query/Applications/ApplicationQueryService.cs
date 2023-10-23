using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Applications;
using Microsoft.Extensions.Logging;

namespace Toyar.App.Query.Applications
{
    public class ApplicationQueryService : IApplicationQueryService
    {
        private readonly IToyarEnvironmentRepository _appEnvironmentRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ILogger<ApplicationQueryService> _logger;
        private readonly IContinuousIntegrationImageRepository _buildImageRepository;
        private readonly IBuildImageVersionRepository _buildImageVersionRepository;
        private readonly IComponentIntegrationRepository _componentIntegrationRepository;
        public ApplicationQueryService(IToyarEnvironmentRepository appEnvironmentRepository, IApplicationRepository applicationRepository, ILogger<ApplicationQueryService> logger, IContinuousIntegrationImageRepository buildImageRepository,
            IBuildImageVersionRepository buildImageVersionRepository, IComponentIntegrationRepository componentIntegrationRepository)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _applicationRepository = applicationRepository;
            _logger = logger;
            _buildImageRepository = buildImageRepository;
            _buildImageVersionRepository = buildImageVersionRepository;
            _componentIntegrationRepository = componentIntegrationRepository;
        }


        public async Task<PageBaseResult<ApplicationOutputDto>> GetApplicationPageListAsync(ApplicationQueryDto query)
        {
            var result = await _applicationRepository.GetApplicationPageListAsync(query);

            return new PageBaseResult<ApplicationOutputDto>(result.TotalCount, result.Data.ToArray());
        }

        public async Task<ApplicationOutputDto?> GetApplicationDetailForIdAsync(string id)
        {
            var application = await _applicationRepository.FindFirstOrDefaultByIdAsync(id);
            if (application is null)
                return null;
            return new ApplicationOutputDto
            {
                Id = application.Id,
                AppId = application.AppId,
                Name = application.Name,
                GitUrl = application.GitUrl,
                Describe = application.Describe,
            };
        }

        /// <summary>
        /// 获取应用仪表盘明细信息
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId)
        {
            var application = await _applicationRepository.FindFirstOrDefaultOutputDtoByAppIdAsync(appId);
            return new ApplicationOutput()
            {
                Application = application,
            };
        }

        /// <summary>
        /// 获取应用添加或者修改时所需要获取下拉框的数据
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationSeletedDataOutput> GetApplicationSelectedDataAsync()
        {
            var (Data, _) = await _componentIntegrationRepository.GetComponentIntegrationPageListAsync(new Dto.ComponentIntegrations.ComponentIntegrationQueryDto
            {
                PageIndex = 1,
                PageSize = 1000
            });
            return new ApplicationSeletedDataOutput()
            {
                ComponentIntegrationList = Data.ToList(),

            };
        }
    }
}