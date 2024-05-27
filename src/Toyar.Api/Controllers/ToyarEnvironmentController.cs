using Microsoft.AspNetCore.Mvc;
using Toyar.AppService.ToyarEnvironmentService;
using Toyar.Domain.AggregateRoots.ToyarEnvironments;
using Toyar.Dto.ToyarEnvironments;
using Toyar.Query.ToyarEnvironmentQuery;

namespace Toyar.Api.Controllers;

[Route("api/toyar/environment")]
public class ToyarEnvironmentController  : BaseController
{
    private readonly IToyarEnvironmentService _toyarEnvironmentService;

    public ToyarEnvironmentController(IToyarEnvironmentService toyarEnvironmentService)
    {
        _toyarEnvironmentService = toyarEnvironmentService;
    }

    
    [HttpPost]
    public Task AddEnvironment([FromBody] ToyarEnvironmentInputDto input) => _toyarEnvironmentService.CreateToyarEnvironmentAsync(input);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toyarEnvironmentQueryService"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Task<ToyarEnvironment?> FindEnvironmentDetailForIdAsync([FromServices] IToyarEnvironmentQueryService toyarEnvironmentQueryService, string id)
        => toyarEnvironmentQueryService.FindEnvironmentDetailForIdAsync(id);
}