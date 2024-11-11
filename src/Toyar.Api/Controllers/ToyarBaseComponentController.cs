using Microsoft.AspNetCore.Mvc;
using Toyar.AppService.ToyarApplicationService;
using Toyar.Dto.ToyarApplications;

namespace Toyar.Api.Controllers;

[Route("api/toyarBaseComponent")]
public class ToyarBaseComponentController : BaseController
{
    private readonly IToyarApplicationService _toyarApplicationService;

    public ToyarBaseComponentController(IToyarApplicationService toyarApplicationService)
    {
        _toyarApplicationService = toyarApplicationService;
    }


    [HttpPost("add/toyarApplication")]
    public Task AddToyarApplication([FromBody] ToyarCreateApplicationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationAsync(input);
}