using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Dto.Environments;
using Luck.Walnut.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Luck.Walnut.Query.Applications
{
    public class ApplicationQueryService : IApplicationQueryService
    {
        private readonly IEnvironmentRepository _appEnvironmentRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ApplicationQueryService> _logger;
        private readonly IBuildImageRepository _buildImageRepository;
        private readonly IBuildImageVersionRepository _buildImageVersionRepository;

        public ApplicationQueryService(IEnvironmentRepository appEnvironmentRepository, IApplicationRepository applicationRepository, ILogger<ApplicationQueryService> logger, IProjectRepository projectRepository, IBuildImageRepository buildImageRepository,
            IBuildImageVersionRepository buildImageVersionRepository)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _applicationRepository = applicationRepository;
            _logger = logger;
            _projectRepository = projectRepository;
            _buildImageRepository = buildImageRepository;
            _buildImageVersionRepository = buildImageVersionRepository;
        }


        public async Task<PageBaseResult<ApplicationOutputDto>> GetApplicationPageListAsync(ApplicationQueryDto query)
        {
            var result = await _applicationRepository.GetApplicationPageListAsync(query);
            var projectList = await _projectRepository.GetProjectPageListAsync(result.Data.Select(x => x.ProjectId).ToList());
            if (projectList.Any())
            {
                foreach (var application in result.Data)
                {
                    var project = projectList.FirstOrDefault(x => x.Id == application.ProjectId);
                    if (project is not null)
                    {
                        application.ProjectName = project.Name;
                    }
                }
            }

            return new PageBaseResult<ApplicationOutputDto>(result.TotalCount, result.Data.ToArray());
        }


        public async Task<List<AppEnvironmentListOutputDto>> GetEnvironmentAsync(string appId)
        {
            return await _appEnvironmentRepository.GetEnvironmentListForApplicationId(appId);
        }

        public async Task<ApplicationOutputDto?> GetApplicationDetailForIdAsync(string id)
        {
            var application = await _applicationRepository.FindFirstOrDefaultByIdAsync(id);
            if (application is null)
                return null;
            var applicationOutputDto = new ApplicationOutputDto
            {
                Id = application.Id,
                AppId = application.AppId,
                ApplicationState = application.ApplicationState,
                EnglishName = application.EnglishName,
                ChineseName = application.ChineseName,
                DepartmentName = application.DepartmentName,
                Principal = application.Principal,
                ProjectId = application.ProjectId,
                Describe = application.Describe,
                ApplicationLevel = application.ApplicationLevel,
                BuildImageId = application.BuildImageId
            };
            return applicationOutputDto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Language> GetLanguageListAsync()
        {
            List<Language> languages = new List<Language>()
            {
                new Language(".Net", LanguageTypeEnum.DotNet),
                new Language("Python", LanguageTypeEnum.Python),
                new Language("Java", LanguageTypeEnum.Java),
                new Language("Go", LanguageTypeEnum.Go),
                new Language("Node", LanguageTypeEnum.NodeJs),
            };
            return languages.ToArray();
        }

        /// <summary>
        /// 获取应用仪表盘明细信息
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId)
        {
            var application = await _applicationRepository.FindFirstOrDefaultOutputDtoByAppIdAsync(appId);
            var environmentList = await _appEnvironmentRepository.GetEnvironmentListForApplicationId(appId);
            var buildImage = await _buildImageRepository.FindFirstByIdAsync(application.BuildImageId);
            var buildImageVersionList = await _buildImageVersionRepository.FindListAsync(buildImage.Id);

            ApplicationOutput applicationOutput = new ApplicationOutput();
            applicationOutput.Application = application;
            applicationOutput.EnvironmentList = environmentList;
            applicationOutput.Application.CompileScript = buildImage.CompileScript;
            applicationOutput.Application.BuildImageName = buildImage.BuildImageName;
            applicationOutput.BuildImageVersionList = buildImageVersionList;
            return applicationOutput;
        }
    }
}