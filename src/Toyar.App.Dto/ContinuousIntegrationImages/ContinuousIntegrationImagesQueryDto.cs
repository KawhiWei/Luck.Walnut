namespace Toyar.App.Dto.ContinuousIntegrationImages
{
    public class ContinuousIntegrationImagesQueryDto : PageBaseInputDto
    {
        public string? Name { get; set; } 

        public string? BuildImageName { get; set; } 
    }
}
