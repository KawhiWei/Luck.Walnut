using Luck.Framework.UnitOfWorks;
using Toyar.Domain.AggregateRoots.ToyarBaseComponents;
using Toyar.Domain.Repositories;
using Toyar.Dto.ToyarBaseComponents;

namespace Toyar.AppService.ToyarBaseComponentService;

public class ToyarBaseComponentService : IToyarBaseComponentService
{
    private readonly IToyarBaseComponentRepository _toyarBaseComponentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ToyarBaseComponentService(
        IToyarBaseComponentRepository toyarBaseComponentRepository,
        IUnitOfWork unitOfWork)
    {
        _toyarBaseComponentRepository = toyarBaseComponentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddToyarBaseComponentAsync(ToyarBaseComponentInput input)
    {
        var toyarBaseComponent = new ToyarBaseComponent(input.EnglishName, input.ChinesName, input.Url,
            input.CertificateType, input.Token, input.Account, input.Password);

        _toyarBaseComponentRepository.Add(toyarBaseComponent);
        await _unitOfWork.CommitAsync();
    }
}