using Luck.Framework.Exceptions;
using Luck.Framework.Extensions;
using Luck.Framework.Threading;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.Environments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Environments;
using MediatR;

namespace Toyar.App.AppService.Environments
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _appEnvironmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly ICancellationTokenProvider _cancellationTokenProvider; //当中断请求时，所以有操作同时也中断

        public EnvironmentService(IEnvironmentRepository appEnvironmentRepository,
            IUnitOfWork unitOfWork, ICancellationTokenProvider cancellationTokenProvider, IMediator mediator)
        {
            _appEnvironmentRepository = appEnvironmentRepository;
            _unitOfWork = unitOfWork;
            _cancellationTokenProvider = cancellationTokenProvider;
            _mediator = mediator;
        }

        private const string FindEnvironmentNotExistErrorMsg = "环境数据不存在!!!!";

        public async Task CreateEnvironmentAsync(AppEnvironmentInputDto input)
        {
            await CheckAppEnvironmentExistAsync(input.EnvironmentName);
            var appEnvironment = new AppEnvironment(input.EnvironmentName, input.EnvironmentChinesName);
            _appEnvironmentRepository.Add(appEnvironment);
            await _unitOfWork.CommitAsync(_cancellationTokenProvider.Token);
        }

        public async Task DeleteEnvironmentAsync(string id)
        {
            var appEnvironment = await FindAppEnvironmentByIdAsync(id);

            await CheckAppEnvironmentExistByIdAsync(id);
            //只删除环境？ 要不要把配置也删除？级联删除？
            _appEnvironmentRepository.Remove(appEnvironment);
            await _unitOfWork.CommitAsync(_cancellationTokenProvider.Token);
        }

        private async Task CheckAppEnvironmentExistAsync(string environmentName)
        {
            var appEnvironment = await _appEnvironmentRepository.FirstOrDefaultByEnvironmentNameAsync(environmentName);
            if (appEnvironment is not null)
            {
                throw new BusinessException($"[{environmentName}]已存在");
            }
        }

        private async Task CheckAppEnvironmentExistByIdAsync(string id)
        {
            var appEnvironment = await _appEnvironmentRepository.FirstOrDefaultByIdAsync(id);
            if (appEnvironment is not null)
            {
                throw new BusinessException($"{FindEnvironmentNotExistErrorMsg}");
            }
        }


        private async Task<AppEnvironment> FindAppEnvironmentByIdAsync(string id)
        {
            id.NotNullOrEmpty(nameof(id));
            var appEnvironment = await _appEnvironmentRepository.FindAll(x => x.Id == id).FirstOrDefaultAsync();
            return appEnvironment is null ? throw new BusinessException(FindEnvironmentNotExistErrorMsg) : appEnvironment;
        }
    }
}