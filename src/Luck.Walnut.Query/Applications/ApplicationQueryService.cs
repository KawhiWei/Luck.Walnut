using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Languages;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Dto.Environments;
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


        public async Task<PageBaseResult<ApplicationOutputDto>> GetApplicationListAsync(ApplicationQueryDto query)
        {
            _logger.LogInformation("查询应用列表", query);
            var totalCount = await _applicationRepository.FindAll().CountAsync();
            var applicationList = await _applicationRepository.FindListAsync(query);
            var projectList = await _projectRepository.GetProjectPageListAsync(applicationList.Select(x => x.ProjectId).ToList());
            if (projectList.Any())
            {
                foreach (var application in applicationList)
                {
                    var project = projectList.FirstOrDefault(x => x.Id == application.ProjectId);
                    if (project is not null)
                    {
                        application.ProjectName = project.Name;
                    }
                }
            }

            return new PageBaseResult<ApplicationOutputDto>(totalCount, applicationList.ToArray());
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
            var applicationStateEnumNames = Enum.GetNames(applicationStateEnumType);
            Dictionary<string, string> dictionary = new Dictionary<string, string>(applicationStateEnumNames.Length);
            foreach (var name in applicationStateEnumNames)
            {
                var member = applicationStateEnumType.GetMember(name).FirstOrDefault();
                if (member is null)
                    dictionary.Add(name.ToString(), "");
                else
                    dictionary.Add(name.ToString(), member.ToDescription());
            }
            
            
            var applicationLevelEnumType = typeof(ApplicationLevelEnum);
            var applicationLevelEnumNames = Enum.GetNames(applicationLevelEnumType);
            Dictionary<string, string> applicationLevelDictionary = new Dictionary<string, string>(applicationLevelEnumNames.Length);
            foreach (var name in applicationLevelEnumNames)
            {
                var member = applicationLevelEnumType.GetMember(name).FirstOrDefault();
                if (member is null)
                    applicationLevelDictionary.Add(name.ToString(), "");
                else
                    applicationLevelDictionary.Add(name.ToString(), member.ToDescription());
            }
            return new
            {
                ApplicationStateEnumList = dictionary.ToArray(),
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
                new Language(".Net"),
                new Language("Python"),
                new Language("Java"),
                new Language("Go"),
                new Language("Node"),
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
            var environmentList= await _appEnvironmentRepository.GetEnvironmentListForApplicationId(appId);
            ApplicationOutput applicationOutput = new ApplicationOutput();
            applicationOutput.Application = application;
            applicationOutput.EnvironmentList = environmentList;
            return applicationOutput;
        }
    }
}