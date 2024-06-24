using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarApplicationDto;

namespace Toyar.AppService.ToyarApplicationService;

public class ToyarApplicationService : IToyarApplicationService
{
    private readonly IToyarApplicationRepository _toyarApplicationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ToyarApplicationService(IToyarApplicationRepository toyarApplicationRepository, IUnitOfWork unitOfWork)
    {
        _toyarApplicationRepository = toyarApplicationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddToyarApplicationAsync(ToyarApplicationInputDto input)
    {
        var exist = await CheckToyarApplicationExistAsync(input.AppId);
        if (exist)
        {
            throw new BusinessException($"应用：【{input.AppId}】已存在！");
        }

        var toyarApplication = new ToyarApplication(input.AppId, input.AppName, input.ModuleGit, input.AppType,
            input.OwnedUser, input.DeployType, input.AppDeployStatusType, input.Note, input.IsUseDeployTemplate);

        if (input.EnvironmentIdList.Any())
        {
            foreach (var environmentId in input.EnvironmentIdList)
            {
                toyarApplication.AddToyarAppEnvironmentRelation(environmentId);
            }
        }

        foreach (var toyarApplicationToyarApplicationEnvironmentRelation in toyarApplication
                     .ToyarApplicationEnvironmentRelations)
        {
            toyarApplication.AddToyarApplicationDeploymentConfiguration(
                toyarApplicationToyarApplicationEnvironmentRelation.EnvironmentId, "http", "", "2",
                new List<string>() { "8080" }, "", "", "", "", "8000", false);
        }
        
        
        _toyarApplicationRepository.Add(toyarApplication);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteToyarAppByIdAsync(string appId)
    {
        var toyarApp = await CheckAndGetToyarApplicationByAppId(appId);
        _toyarApplicationRepository.Remove(toyarApp);
        await _unitOfWork.CommitAsync();
    }

    public async Task AddToyarApplicationPermissionRelationAsync(string appId,
        ToyarApplicationPermissionRelationInputDto input)
    {
        var toyarApp = await CheckAndGetToyarApplicationByAppId(appId, true);
        toyarApp.AddToyarAppPermissionRelation(input.UserId, input.EnvironmentId, input.RoleId);
    }

    public async Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId)
    {
        var toyarApp = await CheckAndGetToyarApplicationByAppId(appId, true);
        toyarApp.DeleteToyarAppPermissionRelation(permissionId);
    }

    public async Task AddToyarApplicationEnvironmentRelationAsync(string appId,
        ToyarApplicationEnvironmentRelationInputDto input)
    {
        var toyarApplication = await CheckAndGetToyarApplicationByAppId(appId);
        if (input.EnvironmentIdList.Any())
        {
            foreach (var environmentId in input.EnvironmentIdList)
            {
                toyarApplication.AddToyarAppEnvironmentRelation(environmentId);
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="appId"></param>
    /// <param name="input"></param>
    public async Task AddToyarApplicationDeploymentConfigurationAsync(string appId,
        ToyarApplicationDeploymentConfigurationInputDto input)
    {
        var toyarApp = await CheckAndGetToyarApplicationByAppId(appId, true);

        toyarApp.AddToyarApplicationDeploymentConfiguration(input.EnvironmentId, input.HealthCheckMode,
            input.HealthCheckUrl,
            input.ReleaseStrategy, input.ServicePort, input.BotNotificationType, input.BotNotificationUrl,
            input.DeploymentBeforeWebHookUrl, input.DeploymentAfterWebHookUrl, input.MemorySizeMaxMib, false);
    }
    
    
    private async Task<ToyarApplication> CheckAndGetToyarApplicationByAppId(string appId, bool isInclude = false)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId, isInclude);
        if (toyarApp is null)
        {
            throw new BusinessException($"应用：【{appId}】不存在！");
        }

        return toyarApp;
    }

    private async Task<bool> CheckToyarApplicationExistAsync(string appId)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId);

        return toyarApp is null;
    }

    private async Task<ToyarApplication?> GetToyarApplicationByAppId(string appId, bool isInclude = false)
    {
        return await _toyarApplicationRepository.FindToyarAppByAppId(appId, isInclude);
    }
}