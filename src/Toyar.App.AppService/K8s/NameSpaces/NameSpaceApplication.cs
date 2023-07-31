using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Adapter.K8sAdapter.NameSpaces;
using Toyar.App.Domain.AggregateRoots.K8s.Clusters;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.Repositories;
using Toyar.App.Domain.Shared.Enums;
using Toyar.App.Dto.K8s.NameSpaces;


namespace Toyar.App.AppService.K8s.NameSpaces;

public class NameSpaceApplication : INameSpaceApplication
{
    private readonly INameSpaceRepository _nameSpaceRepository;
    private readonly IUnitOfWork _unitOfWork;


    private readonly IClusterRepository _clusterRepository;
    private readonly INameSpaceAdaper _nameSpaceAdaper;

    public NameSpaceApplication(INameSpaceRepository nameSpaceRepository, IUnitOfWork unitOfWork, IClusterRepository clusterRepository
        , INameSpaceAdaper nameSpaceAdaper
        )
    {
        _nameSpaceRepository = nameSpaceRepository;
        _unitOfWork = unitOfWork;
        _clusterRepository = clusterRepository;
        _nameSpaceAdaper = nameSpaceAdaper;
    }


    /// <summary>
    /// 创建命名空间
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="BusinessException"></exception>
    public async Task CreateNameSpaceAsync(NameSpaceInputDto input)
    {
        if (await CheckIsExitNameSpaceNameAsync(input.Name, input.ClusterId))
        {
            throw new BusinessException($"[{input.Name}]已存在，请刷新页面");
        }

        var nameSpace = new NameSpace(input.ChineseName, input.Name, input.ClusterId);
        _nameSpaceRepository.Add(nameSpace);
        await _unitOfWork.CommitAsync();
    }


    /// <summary>
    /// 修改命名空间
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>

    public async Task UpdateNameSpaceAsync(string id, NameSpaceInputDto input)
    {
        var nameSpace = await GetAndCheckNameSpaceAsync(id);
        nameSpace.Update(input).SetOnline(OnlineStatusEnum.Offline);
        await _unitOfWork.CommitAsync();
    }


    /// <summary>
    /// 上线命名空间
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task OnlineNameSpaceAsync(string id)
    {
        var nameSpace = await GetAndCheckNameSpaceAsync(id);
        var cluster = await CheckAndGetCluster(nameSpace.ClusterId);
        await _nameSpaceAdaper.CreateNameSpaceAsync(CreateKubernetesNameSpacePublishContext(nameSpace, cluster.Config));
        nameSpace.SetOnline(OnlineStatusEnum.Online);
        await _unitOfWork.CommitAsync();
    }


    /// <summary>
    /// 下线命名空间
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task OfflineNameSpaceAsync(string id)
    {
        var nameSpace = await GetAndCheckNameSpaceAsync(id);
        var cluster = await CheckAndGetCluster(nameSpace.ClusterId);
        await _nameSpaceAdaper.DeleteNameSpaceAsync(CreateKubernetesNameSpacePublishContext(nameSpace, cluster.Config));
        nameSpace.SetOnline(OnlineStatusEnum.Offline);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 删除命名空间
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteNameSpaceAsync(string id)
    {
        var nameSpace = await GetAndCheckNameSpaceAsync(id);
        _nameSpaceRepository.Remove(nameSpace);
        await _unitOfWork.CommitAsync();
    }

    /// <summary>
    /// 根据一个Id获取一个NameSpace，并检查是否存在
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="BusinessException"></exception>
    private async Task<NameSpace> GetAndCheckNameSpaceAsync(string id)
    {
        var nameSpace = await _nameSpaceRepository.FindNameSpaceByIdAsync(id);
        if (nameSpace is null)
        {
            throw new BusinessException($"NameSpace不存在，请刷新页面");
        }

        if (nameSpace.OnlineStatus == OnlineStatusEnum.Online)
        {
            throw new BusinessException($"不可重复发布，请刷新页面");
        }

        return nameSpace;
    }

    /// <summary>
    /// 检查命名空间名称是否存在
    /// </summary>
    /// <param name="name"></param>
    /// <param name="clusterId"></param>
    /// <returns></returns>
    private async Task<bool> CheckIsExitNameSpaceNameAsync(string name, string clusterId)
    {
        var nameSpace = await _nameSpaceRepository.FindNameSpaceByNameAndClusterIdAsync(name, clusterId);
        return nameSpace is not null;
    }

    private async Task<Cluster> CheckAndGetCluster(string id)
    {
        var cluster = await _clusterRepository.FirstOrDefaultByIdAsync(id);
        return cluster is null ? throw new BusinessException($"集群不存在") : cluster;
    }


    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="nameSpace"></param>
    /// <param name="connectStr"></param>
    /// <returns></returns>
    private static KubernetesNameSpacePublishContext CreateKubernetesNameSpacePublishContext(NameSpace nameSpace, string connectStr)
    {
        return new KubernetesNameSpacePublishContext(connectStr, nameSpace);
    }

}