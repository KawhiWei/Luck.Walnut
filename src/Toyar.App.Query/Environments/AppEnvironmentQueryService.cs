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
    public class AppEnvironmentQueryService : IAppEnvironmentQueryService
    {
        private readonly IEnvironmentRepository _appEnvironmentRepository;
        private readonly IEntityRepository<AppConfiguration, string> _appConfigurationRepository;
        private readonly ICancellationTokenProvider _cancellationTokenProvider; //当中断请求时，所以有操作同时也中断
        private const string FindAppConfigurationNotExistErrorMsg = "配置数据不存在!!!!";

        public AppEnvironmentQueryService(IEnvironmentRepository appEnvironmentRepository,
            ICancellationTokenProvider cancellationTokenProvider,
            IEntityRepository<AppConfiguration, string> appConfigurationRepository)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _appConfigurationRepository = appConfigurationRepository;
            _cancellationTokenProvider = cancellationTokenProvider;
        }
    }
}