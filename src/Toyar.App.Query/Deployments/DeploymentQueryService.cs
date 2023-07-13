using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.Deployments;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Deployments;
using Toyar.App.Dto.K8s.Clusters;
using Toyar.App.Persistence.Repositories;

namespace Toyar.App.Query.Deployments;

public class DeploymentQueryService : IDeploymentQueryService
{
    private readonly IDeploymentRepository _deploymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public DeploymentQueryService(IDeploymentRepository deploymentRepository, IUnitOfWork unitOfWork)
    {
        _deploymentRepository = deploymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeploymentOutputDto> GetDeploymentForIdAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);



        return StructureDeploymentOutputDto(deployment);
    }


    public async Task<PageBaseResult<DeploymentOutputDto>> GetDeploymentPageListAsync(string appId, DeploymentQueryDto query)
    {
        var (Data, TotalCount) = await _deploymentRepository.GetDeploymentPageListAsync(appId, query);
        return new PageBaseResult<DeploymentOutputDto>(TotalCount, Data.Select(cluster => StructureDeploymentOutputDto(cluster)).ToArray());
    }






    private static DeploymentOutputDto StructureDeploymentOutputDto(Deployment deployment)
    {
        return new DeploymentOutputDto
        {

        };

    }




    private async Task<Deployment> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _deploymentRepository.FirstOrDefaultByIdAsync(id);
        return deployment is null ? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}") : deployment;
    }





}
