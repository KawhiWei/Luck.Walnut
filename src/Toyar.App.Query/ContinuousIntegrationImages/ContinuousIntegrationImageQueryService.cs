using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.Query.ContinuousIntegrationImages
{
    public class ContinuousIntegrationImageQueryService : IContinuousIntegrationImageQueryService
    {
        private readonly IContinuousIntegrationImageRepository _continuousIntegrationImageRepository;

        public ContinuousIntegrationImageQueryService(IContinuousIntegrationImageRepository  continuousIntegrationImageRepository) 
        {
            _continuousIntegrationImageRepository = continuousIntegrationImageRepository;
        }

        /// <summary>
        /// 查询全部镜像
        /// </summary>
        /// <returns></returns>
        public Task<List<ContinuousIntegrationImageOutputDto>> GetBuildImages()
        {
            var buildImages = _continuousIntegrationImageRepository.FindAll();
            return buildImages.Select(p => new ContinuousIntegrationImageOutputDto
            {
                Id = p.Id,
                CompileScript = p.RegistryUrl,
                Name = p.Name,
            }).ToListAsync();
        }

        /// <summary>
        /// 分页查询全部镜像
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PageBaseResult<ContinuousIntegrationImageOutputDto>> GetBuildImagesPageList(ContinuousIntegrationImagesQueryDto query)
        {
            var buildImages = await _continuousIntegrationImageRepository.GetBuildImagePageListAsync(query);

            return new PageBaseResult<ContinuousIntegrationImageOutputDto>(buildImages.TotalCount, buildImages.Data.ToArray());
        }

        public async Task<ContinuousIntegrationImageOutputDto> GetBuildImagesPageById(string id)
        {
            var buildImage = await  _continuousIntegrationImageRepository.FindFirstByIdAsync(id);
            return new ContinuousIntegrationImageOutputDto
            {
                Id = buildImage.Id,
                CompileScript = buildImage.RegistryUrl,
                Name = buildImage.Name
            };
        }

    }
}
