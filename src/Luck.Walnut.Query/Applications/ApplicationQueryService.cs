﻿using Luck.DDD.Domain.Repositories;
using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.Environments;
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

        public async Task<ApplicationOutputDto> GetApplicationDetailForIdAsync(string appId)
        {
            var applicationOutputDto = await _applicationRepository.FindFirstOrDefaultOutputDtoByAppIdAsync(appId);
            return applicationOutputDto;
        }

        public IEnumerable<KeyValuePair<string, string>> GetApplicationEnumList()
        {
            var type = typeof(ApplicationStateEnum);
            var names = Enum.GetNames(type);
            Dictionary<string, string> dictionary = new Dictionary<string, string>(names.Length);
            foreach (var name in names)
            {
                var member = type.GetMember(name).FirstOrDefault();
                if (member is null)
                    dictionary.Add(name.ToString(), "");
                else
                    dictionary.Add(name.ToString(), member.ToDescription());
            }

            return dictionary.ToArray();
        }


        /// <summary>
        /// 获取应用仪表盘明细信息
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationOutput> GetApplicationDashboardDetailAsync(string appId)
        {
            var application = await _applicationRepository.FindFirstOrDefaultOutputDtoByAppIdAsync(appId);
            ApplicationOutput applicationOutput = new ApplicationOutput();
            applicationOutput.Application = application;

            return applicationOutput;
        }
    }
}