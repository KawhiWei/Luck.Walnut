using Microsoft.AspNetCore.Mvc;
using Toyar.App.AppService.K8s.Clusters;
using Toyar.App.Dto;
using Toyar.App.Dto.K8s.Clusters;
using Toyar.App.Query.K8s.Clusters;

namespace Toyar.App.Api.Controllers;

[ApiController]
[Route("api/clusters")]
public class ClusterController : BaseController
{

    /// <summary>
    /// 创建集群
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task CreateClusterAsync([FromServices] IClusterService clusterService, [FromBody] ClusterInputDto input) => clusterService.CreateClusterAsync(input);

    /// <summary>
    /// 修改集群
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateClusterAsync([FromServices] IClusterService clusterService, string id, [FromBody] ClusterInputDto input) => clusterService.UpdateClusterAsync(id, input);

    /// <summary>
    /// 删除集群
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteClusterAsync([FromServices] IClusterService clusterService, string id) => clusterService.DeleteClusterAsync(id);


    /// <summary>
    /// 根据Id获取一个集群信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<ClusterOutputDto> GetClusterByIdAsync([FromServices] IClusterQueryService clusterQueryService, string id) => clusterQueryService.GetClusterByIdAsync(id);

    /// <summary>
    /// 分页获取集群
    /// </summary>
    /// <param name="applicationQueryDto"></param>
    /// <param name="applicationQueryService"></param>
    /// <returns></returns>
    [HttpGet("page/list")]
    public Task<PageBaseResult<ClusterOutputDto>> GetClusterPageListAsync([FromQuery] ClusterQueryDto query, [FromServices] IClusterQueryService clusterQueryService) => clusterQueryService.GetClusterPageListAsync(query);
}