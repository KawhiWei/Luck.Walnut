using Luck.Framework.Exceptions;
using Luck.Framework.Threading;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Environments;

namespace Toyar.App.AppService.Environments
{
    public class ToyarEnvironmentService : IToyarEnvironmentService
    {
        private readonly IToyarEnvironmentRepository _toyarEenvironmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICancellationTokenProvider _cancellationTokenProvider; //当中断请求时，所以有操作同时也中断

        public ToyarEnvironmentService(IToyarEnvironmentRepository toyarEnvironmentRepository,
            IUnitOfWork unitOfWork, ICancellationTokenProvider cancellationTokenProvider)
        {
            _toyarEenvironmentRepository = toyarEnvironmentRepository;
            _unitOfWork = unitOfWork;
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        private const string FindEnvironmentNotExistErrorMsg = "环境不存在!!!!";

        public async Task CreateEnvironmentAsync(ToyarEnvironmentInputDto input)
        {
            await CheckAppEnvironmentExistAsync(input.Name);
            var appEnvironment = new Domain.AggregateRoots.Environments.ToyarEnvironment(input.Name, input.ChinesName);
            _toyarEenvironmentRepository.Add(appEnvironment);
            await _unitOfWork.CommitAsync(_cancellationTokenProvider.Token);
        }

        public async Task DeleteEnvironmentAsync(string id)
        {
            var appEnvironment = await CheckAndGetEnvironmentExistByIdAsync(id);
            _toyarEenvironmentRepository.Remove(appEnvironment);
            await _unitOfWork.CommitAsync(_cancellationTokenProvider.Token);
        }

        private async Task CheckAppEnvironmentExistAsync(string environmentName)
        {
            var appEnvironment = await _toyarEenvironmentRepository.FirstOrDefaultByNameAsync(environmentName);
            if (appEnvironment is not null)
            {
                throw new BusinessException($"[{environmentName}]已存在");
            }
        }

        private async Task<ToyarEnvironment> CheckAndGetEnvironmentExistByIdAsync(string id)
        {
            var environment = await _toyarEenvironmentRepository.FirstOrDefaultByIdAsync(id);
            return environment is null ? throw new BusinessException($"{FindEnvironmentNotExistErrorMsg}") : environment;
        }
    }
}