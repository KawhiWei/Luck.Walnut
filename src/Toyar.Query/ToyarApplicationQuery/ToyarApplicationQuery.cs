using Luck.AutoDependencyInjection;
using Toyar.Domain.AggregateRoots.ToyarApplications;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarApplications;
using Toyar.Dto.ToyarEnvironments;

namespace Toyar.Query.ToyarApplicationQuery;

[DependencyInjection(ServiceLifetime.Scoped)]
public class ToyarApplicationQuery : IToyarApplicationQuery
{
    private readonly IToyarApplicationRepository _toyarApplicationRepository;

    public ToyarApplicationQuery(IToyarApplicationRepository toyarApplicationRepository)
    {
        _toyarApplicationRepository = toyarApplicationRepository;
    }

    public async Task<ToyarApplicationOutputDto> QueryToyarApplicationByAppId(string appId)
    {
        var toyarApplication = await GetToyarApplicationByAppId(appId, true);
        if (toyarApplication is null)
        {
            throw new BusinessException($"应用：【{appId}】不存在！");
        }


        return new ToyarApplicationOutputDto()
        {
            AppId = toyarApplication.AppId,
            AppName = toyarApplication.AppName,
            ModuleGit = toyarApplication.ModuleGit,
            AppType = toyarApplication.AppType,
            OwnedUser = toyarApplication.OwnedUser,
            DeployType = toyarApplication.InstanceType,
            AppDeployStatusType = toyarApplication.AppDeployStatusType,
            Note = toyarApplication.Note,
            IsUseDeployTemplate = toyarApplication.IsUseDeployTemplate,
            ToyarEnvironmentOutputList = toyarApplication.ToyarApplicationEnvironmentRelations
                .Select(x => new ToyarEnvironmentOutputDto
                {
                    Id = x.Id,
                    EnvironmentId = x.EnvironmentId,
                }).ToList()
        };
    }

    private async Task<ToyarApplication?> GetToyarApplicationByAppId(string appId, bool isInclude = false)
    {
        return await _toyarApplicationRepository.FindToyarAppByAppId(appId, isInclude);
    }
}