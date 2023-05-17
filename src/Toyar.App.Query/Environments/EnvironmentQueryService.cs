using Luck.DDD.Domain.Repositories;
using Luck.Framework.Exceptions;
using Luck.Framework.Threading;
using Toyar.App.Domain.AggregateRoots.Applications;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Query.Environments
{
    public class EnvironmentQueryService : IEnvironmentQueryService
    {
        private readonly IEnvironmentRepository _appEnvironmentRepository;
        private readonly IEntityRepository<AppConfiguration, string> _appConfigurationRepository;
        private readonly ICancellationTokenProvider _cancellationTokenProvider; //当中断请求时，所以有操作同时也中断
        private const string FindAppConfigurationNotExistErrorMsg = "配置数据不存在!!!!";

        public EnvironmentQueryService(IEnvironmentRepository appEnvironmentRepository,
            ICancellationTokenProvider cancellationTokenProvider,
            IEntityRepository<AppConfiguration, string> appConfigurationRepository)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _appConfigurationRepository = appConfigurationRepository;
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        public Task<PageBaseResult<AppConfigurationOutputDto>> GetAppEnvironmentConfigurationPageAsync(
            string environmentId, PageBaseInputDto baseInputDto)
        {
          return  _appEnvironmentRepository.GetAppConfigurationPageAsync(environmentId, baseInputDto);
        }

        public async Task<AppConfigurationOutputDto> GetConfigurationDetailForConfigurationIdAsync(
            string configurationId)
        {
            var appconfigutation = await GetConfigurationDetailByIdAsync(configurationId);
            return new AppConfigurationOutputDto()
            {
                Id = appconfigutation.Id,
                Key = appconfigutation.Key,
                Value = appconfigutation.Value,
                IsOpen = appconfigutation.IsOpen,
                IsPublish = appconfigutation.IsPublish,
                Type = appconfigutation.Type,
            };
        }

        private async Task<AppConfiguration> GetConfigurationDetailByIdAsync(string configurationId)
        {
            var appConfiguration = await _appConfigurationRepository.FindAsync(configurationId);
            if (appConfiguration is null) throw new BusinessException(FindAppConfigurationNotExistErrorMsg);
            return appConfiguration;
        }

        public async Task<AppEnvironmentOutputDto> GetAppConfigurationByAppIdAndEnvironmentNameAsync(string appId,
            string environmentName)
        {
            var appEnvironment = await _appEnvironmentRepository
                .FindAll(x => x.AppId == appId && x.EnvironmentName == environmentName).Include(x => x.Configurations)
                .FirstOrDefaultAsync();
            if (appEnvironment is null)
            {
                throw new BusinessException($"{appId}不存在此环境");
            }

            var configs = appEnvironment.Configurations.Where(x => x.IsPublish).Select(x =>
                new AppConfigurationOutputDto()
                {
                    Key = x.Key, Value = x.Value, Type = x.Type,
                }).ToList();
            return new AppEnvironmentOutputDto()
            {
                EnvironmentName = appEnvironment.EnvironmentName,
                Version = appEnvironment.Version,
                AppId = appEnvironment.AppId,
                Configs = configs,
            };
        }

        public async Task<PageBaseResult<AppEnvironmentPageListOutputDto>> GetToDontPublishAppConfiguration(
            string environmentId, PageBaseInputDto baseInputDto)
        {
            var list = await _appEnvironmentRepository.FindAll().Where(o => o.Id == environmentId)
                .Include(o => o.Configurations).SelectMany(o => o.Configurations).Select(a =>
                    new AppEnvironmentPageListOutputDto
                    {
                        Id = a.Id,
                        IsOpen = a.IsOpen,
                        IsPublish = a.IsPublish,
                        Key = a.Key,
                        Type = a.Type,
                        Value = a.Value,
                    }).Where(o => o.IsPublish == false).ToPage(baseInputDto.PageIndex, baseInputDto.PageSize).ToListAsync();
            var total = await _appEnvironmentRepository.FindAll().Where(o => o.Id == environmentId)
                .Include(o => o.Configurations).SelectMany(o => o.Configurations).Where(o => o.IsPublish == false)
                .CountAsync();
            return new PageBaseResult<AppEnvironmentPageListOutputDto>(total, list.ToArray());
        }
    }
}