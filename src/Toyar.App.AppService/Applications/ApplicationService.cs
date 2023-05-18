﻿using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Applications;

namespace Toyar.App.AppService.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }

        public async Task AddApplicationAsync(ApplicationInputDto input)
        {
            await CheckAppIdAsync(input.AppId);
            _applicationRepository.Add(new Application("", input.Name, input.AppId, input.GitUrl));
            await _unitOfWork.CommitAsync();
        }

        private async Task CheckAppIdAsync(string appId)
        {
            var application = await GetApplicationByAppIdAsync(appId);

            if (application is not null)
                throw new BusinessException($"应用已存在");
        }

        public async Task UpdateApplicationAsync(string id, ApplicationInputDto input)
        {
            var application = await GetApplicationByIdAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteApplicationAsync(string id)
        {
            var application = await GetApplicationByIdAsync(id);
            _applicationRepository.Remove(application);
            await _unitOfWork.CommitAsync();
        }

        private Task<Domain.AggregateRoots.Applications.Application?> GetApplicationByAppIdAsync(string appId) => _applicationRepository.FindFirstOrDefaultByAppIdAsync(appId);

        private async Task<Domain.AggregateRoots.Applications.Application> GetApplicationByIdAsync(string id)
        {
            var application = await _applicationRepository.FindFirstOrDefaultByIdAsync(id);
            if (application is null)
                throw new BusinessException($"应用不存在");
            return application;
        }
    }
}