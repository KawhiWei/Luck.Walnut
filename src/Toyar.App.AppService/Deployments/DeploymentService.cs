using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.Deployments;

namespace Toyar.App.AppService.Deployments;

public class DeploymentService : IDeploymentService
{
    private readonly IDeploymentRepository _deploymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public DeploymentService(IDeploymentRepository deploymentRepository, IUnitOfWork unitOfWork)
    {
        _deploymentRepository = deploymentRepository;
        _unitOfWork = unitOfWork;
    }



    public async Task CreateDeploymentAsync(DeploymentInputDto input)
    {



        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateDeploymentAsync(string id, DeploymentInputDto input)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        await _unitOfWork.CommitAsync();
    }


    public async Task DeleteDeploymentAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        _deploymentRepository.Remove(deployment);
        await _unitOfWork.CommitAsync();
    }

    private async Task<Deployment> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _deploymentRepository.FirstOrDefaultByIdAsync(id);
        return deployment is null ? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}") : deployment;
    }

}
