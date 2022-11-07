using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.Applications;

namespace Luck.Walnut.Application.Applications
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
            var application = new Domain.AggregateRoots.Applications.Application(input.ProjectId, input.EnglishName,
                input.DepartmentName, input.ChinessName, input.Principal, input.AppId, input.ApplicationState, input.Describe, input.CodeWarehouseAddress,ApplicationLevelEnum.LevelZero);
            _applicationRepository.Add(application);
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
            application.UpdateInfo(input.ProjectId, input.EnglishName, input.DepartmentName, input.ChinessName, input.Principal,
                input.AppId, input.ApplicationState, input.Describe, input.CodeWarehouseAddress);
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