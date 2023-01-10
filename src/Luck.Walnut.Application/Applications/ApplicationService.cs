using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Luck.Walnut.Domain.AggregateRoots.Applications;
using Luck.Walnut.Domain.AggregateRoots.ComponentIntegrations;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Domain.Shared.Enums;
using Luck.Walnut.Dto.Applications;
using Luck.Walnut.Persistence.Repositories;

namespace Luck.Walnut.Application.Applications
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IComponentIntegrationRepository componentIntegrationRepository;

        public ApplicationService(IApplicationRepository applicationRepository, IUnitOfWork unitOfWork, IComponentIntegrationRepository componentIntegrationRepository = null)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
            this.componentIntegrationRepository = componentIntegrationRepository;
        }

        public async Task AddApplicationAsync(ApplicationInputDto input)
        {
            await CheckAppIdAsync(input.AppId);
            var application = new Domain.AggregateRoots.Applications.Application(input.ProjectId, input.EnglishName,
                input.DepartmentName, input.ChineseName, input.Principal, input.AppId, input.ApplicationState, 
                ".Net", ApplicationLevelEnum.LevelZero, input.CodeWarehouseAddress, 
                input.Describe,imageWarehouseId:input.ImageWarehouseId,buildImageId:input.BuildImageId);
            var componentIntegration= await componentIntegrationRepository.FindFirstByIdAsync(input.ImageWarehouseId);
            application.SetImageWarehouse(componentIntegration.Credential);
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
            application.UpdateInfo(input.ProjectId, input.EnglishName, input.DepartmentName, input.ChineseName, input.Principal,
                input.AppId, input.ApplicationState, input.ApplicationLevel,input.DevelopmentLanguage, input.Describe,
            input.CodeWarehouseAddress);
            var componentIntegration = await componentIntegrationRepository.FindFirstByIdAsync(input.ImageWarehouseId);
            application.SetImageWarehouse(componentIntegration.Credential);
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