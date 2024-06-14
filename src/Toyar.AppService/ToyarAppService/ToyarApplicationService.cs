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

    public async Task CreateToyarApplicationAsync(ToyarApplicationInputDto input)
    {
        var exist = await CheckToyarAppExistAsync(input.AppId);
        if (exist)
        {
            throw new BusinessException($"应用：【{input.AppId}】已存在！");
        }

        var toyarApp = new ToyarApplication(input.AppId, input.AppName, input.ModuleGit, input.AppType, input.OwnedUser,
            input.DeployType, input.AppDeployStatusType, input.Note, input.IsUseDeployTemplate);

        _toyarApplicationRepository.Add(toyarApp);
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
        var toyarApp = await FindToyarAppByAppId(appId, true);
        if (toyarApp is null)
        {
            throw new NotImplementedException();
        }

        toyarApp.AddToyarAppPermissionRelation(input.UserId, input.EnvironmentId, input.RoleId);
    }

    public async Task DeleteToyarApplicationPermissionRelationAsync(string appId, string permissionId)
    {
        var toyarApp = await FindToyarAppByAppId(appId, true);
        if (toyarApp is null)
        {
            throw new BusinessException($"应用：【{appId}】不存在！");
        }

        toyarApp.DeleteToyarAppPermissionRelation(permissionId);
    }

    private async Task<bool> CheckToyarAppExistAsync(string appId)
    {
        var toyarApp = await FindToyarAppByAppId(appId);

        return toyarApp is null;
    }

    private async Task<ToyarApplication?> FindToyarAppByAppId(string appId, bool isInclude = false)
    {
        return await _toyarApplicationRepository.FindToyarAppByAppId(appId, isInclude);
    }
}