using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarApps;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarApps;

namespace Toyar.AppService.ToyarAppService;

public class ToyarAppService : IToyarAppService
{
    private readonly IToyarAppRepository _toyarAppRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ToyarAppService(IToyarAppRepository toyarAppRepository, IUnitOfWork unitOfWork)
    {
        _toyarAppRepository = toyarAppRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateToyarAppAsync(ToyarAppInputDto input)
    {
        var exist = await CheckToyarAppExistAsync(input.AppId);
        if (exist)
        {
            throw new NotImplementedException();
        }

        var toyarApp = new ToyarApp(input.AppId, input.AppName, input.ModuleGit, input.AppType, input.OwnedUser,
            input.DeployType, input.AppDeployStatusType, input.Note, input.IsUseDeployTemplate);

        _toyarAppRepository.Add(toyarApp);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteToyarAppByIdAsync(string id)
    {
        var toyarApp = await _toyarAppRepository.FindToyarAppByAppId(id, false);
        if (toyarApp is null)
        {
            throw new NotImplementedException();
        }

        _toyarAppRepository.Remove(toyarApp);
        await _unitOfWork.CommitAsync();
    }

    private async Task<bool> CheckToyarAppExistAsync(string appId)
    {
        var toyarApp = await _toyarAppRepository.FindToyarAppByAppId(appId, false);

        return toyarApp is null;
    }
}