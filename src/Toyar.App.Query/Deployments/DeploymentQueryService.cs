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
    private readonly IClusterRepository _clusterRepository;
    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public DeploymentQueryService(IDeploymentRepository deploymentRepository, IClusterRepository clusterRepository)
    {
        _deploymentRepository = deploymentRepository;
        _clusterRepository = clusterRepository;
    }

    public async Task<DeploymentOutputDto> GetDeploymentForIdAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);



        return StructureDeploymentOutputDto(deployment);
    }

    public async Task<PageBaseResult<DeploymentOutputDto>> GetDeploymentPageListAsync(string appId, DeploymentQueryDto query)
    {
        var (Data, TotalCount) = await _deploymentRepository.GetDeploymentPageListAsync(appId, query);

        var clusterList = await _clusterRepository.GetClusterByIdListAsync(Data.Select(x => x.ClusterId).ToList());

        return new PageBaseResult<DeploymentOutputDto>(TotalCount, Data.Select(deployment =>
        {
            var dto = StructureDeploymentOutputDto(deployment);
            var cluster = clusterList.FirstOrDefault(x => x.Id == dto.ClusterId);
            dto.ClusterName = cluster is null ? "" : cluster.Name;

            return dto;


        }




        ).ToArray());
    }


    private static DeploymentOutputDto StructureDeploymentOutputDto(Deployment deployment)
    {
        return new DeploymentOutputDto
        {
            Id = deployment.Id,
            Name = deployment.Name,
            NameSpace = deployment.NameSpace,
            ChineseName = deployment.ChineseName,
            Replicas = deployment.Replicas,
            SideCarPlugins = deployment.SideCars,
            DeploymentType = deployment.DeploymentType,
            ApplicationRuntimeType = deployment.ApplicationRuntimeType,
            EnvironmentName = deployment.EnvironmentName,
            AppId = deployment.AppId,
            ClusterId = deployment.ClusterId,
            DeploymentPlugins = new DeploymentPluginsDto
            {
                StrategyBase= new StrategyBaseDto
                {
                    Type=deployment.DeploymentPlugins.Strategy.Type,
                    MaxSurge=deployment.DeploymentPlugins.Strategy.MaxSurge,
                    MaxUnavailable=deployment.DeploymentPlugins.Strategy.MaxUnavailable,
                }
            }
            
        };

    }




    private async Task<Deployment> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _deploymentRepository.FirstOrDefaultByIdAsync(id);
        return deployment is null ? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}") : deployment;
    }





}
