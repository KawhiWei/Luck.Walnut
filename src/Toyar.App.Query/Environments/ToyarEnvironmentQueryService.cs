using Luck.DDD.Domain.Repositories;
using Luck.Framework.Threading;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Environments;

namespace Toyar.App.Query.Environments
{
    public class ToyarEnvironmentQueryService : IToyarEnvironmentQueryService
    {
        private readonly IToyarEnvironmentRepository _toyarEnvironmentRepository;
        private readonly ICancellationTokenProvider _cancellationTokenProvider; //当中断请求时，所以有操作同时也中断
        private const string FindAppConfigurationNotExistErrorMsg = "环境数据不存在!!!!";

        public ToyarEnvironmentQueryService(IToyarEnvironmentRepository appEnvironmentRepository,
            ICancellationTokenProvider cancellationTokenProvider,
            IEntityRepository<AppConfiguration, string> appConfigurationRepository)
        {
            _toyarEnvironmentRepository = appEnvironmentRepository;
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        public async Task<PageBaseResult<ToyarEnvironmentOutputDto>> GetEnvironmentPageListAsync(ToyarEnvironmentQueryDto query)
        {
            var (Data, TotalCount) = await _toyarEnvironmentRepository.GetPageListAsync(query);
            return new PageBaseResult<ToyarEnvironmentOutputDto>(TotalCount, Data.Select(x => StructureEnvironmentOutputDto(x)).ToArray());
        }


        public async Task<ToyarEnvironmentOutputDto> GetEnvironmentDetailForIdAsync(string id)
        {
            var environment = await CheckAndGetEnvironmentExistByIdAsync(id);
            return StructureEnvironmentOutputDto(environment);
        }



        private async Task<ToyarEnvironment> CheckAndGetEnvironmentExistByIdAsync(string id)
        {
            var environment = await _toyarEnvironmentRepository.FirstOrDefaultByIdAsync(id);
            return environment is null ? throw new BusinessException($"{FindAppConfigurationNotExistErrorMsg}") : environment;
        }

        private static ToyarEnvironmentOutputDto StructureEnvironmentOutputDto(ToyarEnvironment toyarEnvironment)
        {
            return new ToyarEnvironmentOutputDto
            {
                Id = toyarEnvironment.Id,
                Name = toyarEnvironment.Name,
                ChinesName = toyarEnvironment.ChinesName,

            };
        }
    }
}