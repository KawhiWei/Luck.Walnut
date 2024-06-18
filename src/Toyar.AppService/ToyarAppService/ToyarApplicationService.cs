using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

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
        var exist = await CheckToyarAppExistAsync(input.AppId);
        if (exist)
        {
            throw new BusinessException($"应用：【{input.AppId}】已存在！");
        }

        var toyarApplication = new ToyarApplication(input.AppId, input.AppName, input.ModuleGit, input.AppType,
            input.OwnedUser,
            input.DeployType, input.AppDeployStatusType, input.Note, input.IsUseDeployTemplate);

        if (input.EnvironmentIdList.Any())
        {
            foreach (var environmentId in input.EnvironmentIdList)
            {
                toyarApplication.AddToyarAppEnvironmentRelation(environmentId);
            }
        }

        _toyarApplicationRepository.Add(toyarApplication);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteToyarAppByIdAsync(string id)
    {
        var toyarApp = await _toyarApplicationRepository.FindToyarAppByAppId(id, false);
        if (toyarApp is null)
        {
            throw new BusinessException($"应用：【{id}】不存在！");
        }

        _toyarApplicationRepository.Remove(toyarApp);
        await _unitOfWork.CommitAsync();
    }

    public async Task AddToyarApplicationPermissionRelationAsync(string appId,
        ToyarApplicationPermissionRelationInputDto input)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId, true);
        if (toyarApp is null)
        {
            throw new NotImplementedException();
        }

        toyarApp.AddToyarAppPermissionRelation(input.UserId, input.EnvironmentId, input.RoleId);
    }

    public async Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId, true);
        if (toyarApp is null)
        {
            throw new BusinessException($"应用：【{appId}】不存在！");
        }

        toyarApp.DeleteToyarAppPermissionRelation(permissionId);
    }

    public async Task AddToyarApplicationEnvironmentRelationAsync(string appId,
        ToyarApplicationEnvironmentRelationInputDto input)
    {
        var toyarApplication = await CheckAndGetToyarApplicationByAppId(appId);
        if (toyarApplication is null)
        {
            throw new NotImplementedException();
        }

        if (input.EnvironmentIdList.Any())
        {
            foreach (var environmentId in input.EnvironmentIdList)
            {
                toyarApplication.AddToyarAppEnvironmentRelation(environmentId);
            }
        }
    }


    private async Task<ToyarApplication> CheckAndGetToyarApplicationByAppId(string appId)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId, true);
        if (toyarApp is null)
        {
            throw new NotImplementedException();
        }

        return toyarApp;
    }

    private async Task<bool> CheckToyarAppExistAsync(string appId)
    {
        var toyarApp = await GetToyarApplicationByAppId(appId);

        return toyarApp is null;
    }

    private async Task<ToyarApplication?> GetToyarApplicationByAppId(string appId, bool isInclude = false)
    {
        return await _toyarApplicationRepository.FindToyarAppByAppId(appId, isInclude);
    }
}