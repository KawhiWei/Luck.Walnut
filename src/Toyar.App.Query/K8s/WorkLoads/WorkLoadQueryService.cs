using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.WorkLoads;

namespace Toyar.App.Query.K8s.WorkLoads;

public class WorkLoadQueryService : IWorkLoadQueryService
{
    private readonly IWorkLoadRepository _workLoadRepository;
    private readonly IClusterRepository _clusterRepository;
    private const string FindDeploymentNotExistErrorMsg = "部署不存在!!!!";

    public WorkLoadQueryService(IWorkLoadRepository workLoadRepository, IClusterRepository clusterRepository)
    {
        _workLoadRepository = workLoadRepository;
        _clusterRepository = clusterRepository;
    }

    public async Task<WorkLoadOutputDto> GetWorkLoadForIdAsync(string id)
    {
        var deployment = await CheckAndGetDeploymentAsync(id);
        return StructureWorkLoadOutputDto(deployment);
    }

    public async Task<PageBaseResult<WorkLoadOutputDto>> GetWorkLoadPageListAsync(string appId, WorkLoadQueryDto query)
    {
        var (data, totalCount) = await _workLoadRepository.GetDeploymentPageListAsync(appId, query);

        var clusterList = await _clusterRepository.GetClusterByIdListAsync(data.Select(x => x.ClusterId).ToList());

        return new PageBaseResult<WorkLoadOutputDto>(totalCount, data.Select(deployment =>
        {
            var dto = StructureWorkLoadOutputDto(deployment);
            var cluster = clusterList.FirstOrDefault(x => x.Id == dto.ClusterId);
            dto.ClusterName = cluster is null ? "" : cluster.Name;
            return dto;
        }).ToArray());
    }


    private static WorkLoadOutputDto StructureWorkLoadOutputDto(WorkLoad workLoad)
    {
        return new WorkLoadOutputDto
        {
            Id = workLoad.Id,
            Name = workLoad.Name,
            NameSpace = workLoad.NameSpace,
            ChineseName = workLoad.ChineseName,
            Replicas = workLoad.Replicas,
            SideCarPlugins = workLoad.SideCars,
            DeploymentType = workLoad.DeploymentType,
            ApplicationRuntimeType = workLoad.ApplicationRuntimeType,
            EnvironmentName = workLoad.EnvironmentName,
            AppId = workLoad.AppId,
            ClusterId = workLoad.ClusterId,
            IsPublish = workLoad.IsPublish,
            WorkLoadPlugins = new WorkLoadPluginsDto
            {
                Strategy = new StrategyBaseDto
                {
                    Type = workLoad.DeploymentPlugins.Strategy.Type,
                    MaxSurge = workLoad.DeploymentPlugins.Strategy.MaxSurge,
                    MaxUnavailable = workLoad.DeploymentPlugins.Strategy.MaxUnavailable,
                }
            }
        };
    }




    private async Task<WorkLoad> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _workLoadRepository.FirstOrDefaultByIdAsync(id);
        return deployment ?? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}");
    }





}
