using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Domain.Repositories;
using Toyar.Dto.Environments;
using Toyar.Infrastructure;

namespace Toyar.AppService.Environments;

public class ToyarEnvironmentService : IToyarEnvironmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IToyarEnvironmentRepository _toyarEnvironmentRepository;

    public ToyarEnvironmentService(IUnitOfWork unitOfWork, IToyarEnvironmentRepository toyarEnvironmentRepository)
    {
        _unitOfWork = unitOfWork;
        _toyarEnvironmentRepository = toyarEnvironmentRepository;
    }

    public async Task CreateToyarEnvironmentAsync(ToyarEnvironmentInputDto input)
    {
        var toyarEnvironment = await _toyarEnvironmentRepository.FindToyarEnvironmentByName(input.Name);
        if (toyarEnvironment is not null)
        {
            throw new BusinessException($"环境【{input.Name}】已存在");
        }

        toyarEnvironment = new ToyarEnvironment(
            input.Name,
            input.ChinesName,
            ToyarDefaultConstants.DefaultUserName,
            ToyarDefaultConstants.DefaultUserId,
            ToyarDefaultConstants.DefaultUserName,
            ToyarDefaultConstants.DefaultUserId);

        _toyarEnvironmentRepository.Add(toyarEnvironment);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteToyarEnvironmentByIdAsync(string id)
    {
        var toyarEnvironment = await _toyarEnvironmentRepository.FindAsync(id);
        if (toyarEnvironment is null)
        {
            throw new BusinessException($"环境不存在");
        }

        _toyarEnvironmentRepository.Remove(toyarEnvironment);
        await _unitOfWork.CommitAsync();
    }
}