using System.Diagnostics;
using Toyar.App.Domain.AggregateRoots.K8s.NameSpaces;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.NameSpaces;

namespace Toyar.App.Query.K8s.NameSpaces;

public class NameSpaceQueryService : INameSpaceQueryService
{
    private readonly INameSpaceRepository _nameSpaceRepository;

    private readonly IClusterRepository _clusterRepository;

    public NameSpaceQueryService(INameSpaceRepository nameSpaceRepository, IClusterRepository clusterRepository)
    {
        _nameSpaceRepository = nameSpaceRepository;
        _clusterRepository = clusterRepository;
    }

    public async Task<PageBaseResult<NameSpaceOutputDto>> GetNameSpacePageListAsync(NameSpaceQueryDto query)
    {
        var (data, totalCount) = await _nameSpaceRepository.GetNameSpacePageListAsync(query);
        var clusterList = await _clusterRepository.GetClusterByIdListAsync(data.Select(x => x.ClusterId).ToList());
        var result = data.Select(nameSpace =>
        {
            var nameSpaceOutputDto = CreateNameSpaceOutputDto(nameSpace);
            var cluster = clusterList.FirstOrDefault(cluster => cluster.Id == nameSpace.ClusterId);
            if (cluster is not null)
            {
                nameSpaceOutputDto.ClusterName = cluster.Name;
            }

            return nameSpaceOutputDto;
        });
        return new PageBaseResult<NameSpaceOutputDto>(totalCount, result.ToArray());
    }

    public async Task<NameSpaceOutputDto?> GetNameSpaceDetailByIdAsync(string id)
    {
        var nameSpace = await _nameSpaceRepository.FindNameSpaceByIdAsync(id);

        return nameSpace is null ? null : CreateNameSpaceOutputDto(nameSpace);
    }

    public async Task<List<NameSpaceOutputDto>> GetNameSpaceListAsync()
    {
        var nameSpaceList = await _nameSpaceRepository.GetNameSpaceListAsync();

        return nameSpaceList.Select(CreateNameSpaceOutputDto).ToList();
    }


    private NameSpaceOutputDto CreateNameSpaceOutputDto(NameSpace nameSpace)
    {

        return new NameSpaceOutputDto()
        {
            Name = nameSpace.Name,
            ChineseName = nameSpace.ChineseName,
            ClusterId = nameSpace.ClusterId,
            Id = nameSpace.Id,
            OnlineStatus = nameSpace.OnlineStatus,
        };
    }
}