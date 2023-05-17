using Toyar.App.AppService.ContinuousIntegrationImages;
using Toyar.App.Dto;
using Toyar.App.Dto.ContinuousIntegrationImages;
using Toyar.App.Query.ContinuousIntegrationImages;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers;

[ApiController]
[Route("api/build/images")]
public class ContinuousIntegrationImageController : BaseController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buildImageVersionQueryService"></param>
    /// <param name="imageId"></param>
    /// <returns></returns>
    [HttpGet("{imageId}/version/list")]
    public async Task<List<ContinuousIntegrationImageVersionOutputDto>> GetBuildImageVersionListAsync([FromServices] IBuildImageVersionQueryService buildImageVersionQueryService, string imageId)
    {
        return await buildImageVersionQueryService.FindListAsync(imageId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="continuousIntegrationImageService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public Task AddBuildImage([FromServices] IContinuousIntegrationImageService continuousIntegrationImageService, [FromBody] ContinuousIntegrationImageInputDto input) => continuousIntegrationImageService.AddBuildImageAsync(input);

    /// <summary>
    /// ɾ������
    /// </summary>
    /// <param name="continuousIntegrationImageService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public Task DeleteBuildImage([FromServices] IContinuousIntegrationImageService  continuousIntegrationImageService, string id) => continuousIntegrationImageService.DeleteBuildImageAsync(id);

    /// <summary>
    /// �޸ľ���
    /// </summary>
    /// <param name="continuousIntegrationImageService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public Task UpdateBuildImage([FromServices] IContinuousIntegrationImageService continuousIntegrationImageService, string id, [FromBody] ContinuousIntegrationImageInputDto input) => continuousIntegrationImageService.UpdateBuildImageAsync(id, input);

    /// <summary>
    /// ��ѯ���о���
    /// </summary>
    /// <param name="buildImageQueryService"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<List<ContinuousIntegrationImageOutputDto>> GetBuildImages([FromServices] IContinuousIntegrationImageQueryService buildImageQueryService) => buildImageQueryService.GetBuildImages();

    /// <summary>
    /// ��ҳ��ѯ����
    /// </summary>
    /// <param name="buildImageQueryService"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("page")]
    public Task<PageBaseResult<ContinuousIntegrationImageOutputDto>> GetBuildImagesPageList([FromServices] IContinuousIntegrationImageQueryService buildImageQueryService, [FromQuery] ContinuousIntegrationImagesQueryDto query) => buildImageQueryService.GetBuildImagesPageList(query);

    [HttpGet("{id}")]
    public Task<ContinuousIntegrationImageOutputDto> GetBuildImagesPageById([FromServices] IContinuousIntegrationImageQueryService buildImageQueryService, string id) => buildImageQueryService.GetBuildImagesPageById(id);

    /// <summary>
    /// 添加镜像版本
    /// </summary>
    /// <param name="continuousIntegrationImageService"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("CareatBuildImageVersion")]
    public Task CareatBuildImageVersion([FromServices] IContinuousIntegrationImageService continuousIntegrationImageService, [FromBody] ContinuousIntegrationImageVersionInputDto input) => continuousIntegrationImageService.CareatBuildImageVersion(input);
}