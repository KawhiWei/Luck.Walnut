using Toyar.App.Domain.AggregateRoots.K8s.WorkLoads;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.WorkLoads;
using Toyar.App.Dto.ValueObjects.WorkLoadValueObjects;

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
            WorkLoadType = workLoad.WorkLoadType,
            ApplicationRuntimeType = workLoad.ApplicationRuntimeType,
            EnvironmentName = workLoad.EnvironmentName,
            AppId = workLoad.AppId,
            ClusterId = workLoad.ClusterId,
            IsPublish = workLoad.IsPublish,
            WorkLoadPlugins = new WorkLoadPluginsDto
            {
                Strategy = new StrategyBaseDto
                {
                    Type = workLoad.WorkLoadPlugins.Strategy.Type,
                    MaxSurge = workLoad.WorkLoadPlugins.Strategy.MaxSurge,
                    MaxUnavailable = workLoad.WorkLoadPlugins.Strategy.MaxUnavailable,
                }
            },
            WorkLoadContainers = workLoad.Containers.Select(StructureWorkLoadContainerOutputDto).ToList()
        };
    }
    
    private static WorkLoadContainerOutputDto StructureWorkLoadContainerOutputDto(WorkLoadContainer workLoadContainer)
    {
        var containerPlugins = workLoadContainer.ContainerPlugins;
        return new WorkLoadContainerOutputDto
        {
            Id = workLoadContainer.Id,
            ContainerName = workLoadContainer.ContainerName,
            RestartPolicy=workLoadContainer.RestartPolicy,
            ImagePullPolicy=workLoadContainer.ImagePullPolicy,
            WorkLoadContainerPlugins = new WorkLoadContainerPluginDto()
            {
                Request = containerPlugins.Request is not null?new ContainerResourceQuantityDto
                {
                    Cpu = containerPlugins.Request.Cpu,
                    Memory = containerPlugins.Request.Memory,
                }:null,
                Limit = containerPlugins.Limit is not null?new ContainerResourceQuantityDto
                {
                    Cpu = containerPlugins.Limit.Cpu,
                    Memory = containerPlugins.Limit.Memory,
                }:null,
                ReadNess = containerPlugins.ReadNess is not null?new ContainerSurviveConfigurationDto
                {
                    Path = containerPlugins.ReadNess.Path,
                    Scheme = containerPlugins.ReadNess.Scheme,
                    Port= containerPlugins.ReadNess.Port,
                    InitialDelaySeconds= containerPlugins.ReadNess.InitialDelaySeconds,
                    PeriodSeconds= containerPlugins.ReadNess.PeriodSeconds,
                    
                }:null,
                LiveNess = containerPlugins.LiveNess is not null?new ContainerSurviveConfigurationDto
                {
                    Path = containerPlugins.LiveNess.Path,
                    Scheme = containerPlugins.LiveNess.Scheme,
                    Port= containerPlugins.LiveNess.Port,
                    InitialDelaySeconds= containerPlugins.LiveNess.InitialDelaySeconds,
                    PeriodSeconds= containerPlugins.LiveNess.PeriodSeconds,
                    
                }:null,
                Env=containerPlugins.Env,
                ContainerPorts = containerPlugins.ContainerPorts.Select(x=>new ContainerPortDto
                {
                    Name= x.Name,
                    ContainerPort = x.ContainerPort,
                    Protocol = x.Protocol,                    
                }).ToList()
            }
        };
    }




    private async Task<WorkLoad> CheckAndGetDeploymentAsync(string id)
    {
        var deployment = await _workLoadRepository.FirstOrDefaultByIdAsync(id);
        return deployment ?? throw new BusinessException($"{FindDeploymentNotExistErrorMsg}");
    }





}
