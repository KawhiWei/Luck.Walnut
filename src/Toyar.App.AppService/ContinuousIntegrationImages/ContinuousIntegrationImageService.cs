using Luck.Framework.Exceptions;
using Luck.Framework.UnitOfWorks;
using Toyar.App.Domain.AggregateRoots.ContinuousIntegrationImages;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto.ContinuousIntegrationImages;

namespace Toyar.App.AppService.ContinuousIntegrationImages
{

    public class ContinuousIntegrationImageService : IContinuousIntegrationImageService
    {
        private readonly IContinuousIntegrationImageRepository _buildImageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContinuousIntegrationImageService(IContinuousIntegrationImageRepository buildImageRepository, IUnitOfWork unitOfWork)
        {
            _buildImageRepository = buildImageRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 添加镜像
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task AddBuildImageAsync(ContinuousIntegrationImageInputDto input)
        {
            await CheckBuildImages(input.BuildImageName);
            await _unitOfWork.CommitAsync();
        }

        private async Task CheckBuildImages(string name)
        {
            var buildImage = await GetBuildImagesByName(name);
            if (buildImage is not null)
            {
                throw new BusinessException($"镜像已存在");
            }
        }

        private Task<ContinuousIntegrationImage?> GetBuildImagesByName(string name) => _buildImageRepository.FindFirstByNameAsync(name);

        /// <summary>
        /// 删除镜像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBuildImageAsync(string id)
        {
            var buildImage = await CheckBuildImagesById(id);
            _buildImageRepository.Remove(buildImage);
            await _unitOfWork.CommitAsync();
        }

        private async Task<ContinuousIntegrationImage> CheckBuildImagesById(string id)
        {
            var buildImage = await GetBuildImagesById(id);
            if (buildImage is null)
            {
                throw new BusinessException($"镜像不存在");
            }

            return buildImage;
        }

        private Task<ContinuousIntegrationImage> GetBuildImagesById(string id) => _buildImageRepository.FindFirstByIdAsync(id);

        /// <summary>
        /// 修改镜像
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateBuildImageAsync(string id, ContinuousIntegrationImageInputDto input)
        {
            var buildImage = await CheckBuildImagesById(id);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 添加版本镜像
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CareatBuildImageVersion(ContinuousIntegrationImageVersionInputDto input)
        {
            var buildImage = await _buildImageRepository.FindFirstByIdAsync(input.BuildImageId);
            buildImage.AddBuildImageVersion(input.Version);
            await _unitOfWork.CommitAsync();
        }
    }
}
