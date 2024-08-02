using Toyar.Dto.ToyarEnvironments;

namespace Toyar.Dto.ToyarApplications;

public class ToyarApplicationOutputDto : ToyarApplicationBaseDto
{
    public List<ToyarEnvironmentOutputDto> ToyarEnvironmentOutputList { get; set; } = new();
}