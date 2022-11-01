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

        public ApplicationQueryService(IEnvironmentRepository appEnvironmentRepository, IApplicationRepository applicationRepository, ILogger<ApplicationQueryService> logger, IProjectRepository projectRepository)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _applicationRepository = applicationRepository;
            _logger = logger;
            _projectRepository = projectRepository;
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
                ChinessName = application.ChinessName,
                DepartmentName = application.DepartmentName,
                Principal = application.Principal,
                ProjectId = application.ProjectId,
                Describe = application.Describe,
                ApplicationLevel = application.ApplicationLevel
            };
            return applicationOutputDto;
        }

        public object GetApplicationEnumList()
        {
            var applicationStateEnumType = typeof(ApplicationStateEnum);
            var applicationStateDictionary = applicationStateEnumType.EnumsToDictionary();
            var applicationLevelEnumType = typeof(ApplicationLevelEnum);
            var applicationLevelDictionary = applicationLevelEnumType.EnumsToDictionary();
            return new
            {
                ApplicationStateEnumList = applicationStateDictionary.ToArray(),
                ApplicationLevelEnumList = applicationLevelDictionary.ToArray(),
            };
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
            ApplicationOutput applicationOutput = new ApplicationOutput();
            applicationOutput.Application = application;
            applicationOutput.EnvironmentList = environmentList;
            return applicationOutput;
        }
    }
}