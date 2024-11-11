namespace Toyar.Dto.ToyarApplications;

public class ToyarCreateApplicationInputDto : ToyarApplicationBaseDto
{
    public ContainerConfigurationInputDto ContainerConfiguration { get; set; } = default!;
}