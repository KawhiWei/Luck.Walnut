using Luck.Framework.UnitOfWorks;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarEnvironments;
using Toyar.Infrastructure;

namespace Toyar.AppService.ToyarEnvironmentApp;

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
        var toyarEnvironment = await _toyarEnvironmentRepository.FindToyarEnvironmentByEnglishName(input.EnglishName);
        if (toyarEnvironment is not null)
        {
            throw new BusinessException($"环境【{input.EnglishName}】已存在");
        }

        toyarEnvironment = new Domain.AggregateRoots.ToyarEnvironments.ToyarEnvironment(
            input.EnglishName,
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