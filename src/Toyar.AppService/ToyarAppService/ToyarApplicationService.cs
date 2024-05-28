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

    public async Task CreateToyarAppAsync(ToyarAppInputDto input)
    {
        var exist = await CheckToyarAppExistAsync(input.AppId);
        if (exist)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        _toyarApplicationRepository.Remove(toyarApp);
        await _unitOfWork.CommitAsync();
    }

    public async Task AddToyarAppUserRelationAsync(ToyarAppUserRelationInputDto input)
    {
        var toyarApp = await FindToyarAppByAppId(input.AppId, true);
        if (toyarApp is null)
        {
            throw new NotImplementedException(); 
        }
        
        toyarApp.AddToyarAppUserRelations(input.UserIdList);
        
    }

    private async Task<bool> CheckToyarAppExistAsync(string appId)
    {
        var toyarApp = await FindToyarAppByAppId(appId);

        return toyarApp is null;
    }
    
    private async Task<ToyarApplication?> FindToyarAppByAppId(string appId,bool isInclude=false)
    {
        return await _toyarApplicationRepository.FindToyarAppByAppId(appId, isInclude);
    }
}