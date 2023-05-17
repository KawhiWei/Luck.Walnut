using Toyar.App.AppService.Applications;
using Toyar.App.Domain.Repositories;
using Toyar.App.Dto;
using Toyar.App.Dto.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Toyar.App.Api.Controllers;

[ApiController]
[Route("api/appconfigurations")]
public class AppConfigurationController : BaseController
{
    private readonly ILogger<ApplicationController> _logger;
    private readonly IApplicationService _applicationService;
    private readonly IAppConfigurationRepository _appConfigurationRepository;
    public AppConfigurationController(ILogger<ApplicationController> logger, IApplicationService applicationService, IAppConfigurationRepository appConfigurationRepository)
    {
        _logger = logger;
        _applicationService = applicationService;
        _appConfigurationRepository = appConfigurationRepository;
    }

    [HttpGet]
    public async Task<object> FindListAsync()
    {
        return await _appConfigurationRepository.FindListAsync(new PageBaseInputDto() { PageIndex = 1, PageSize = 12 });
    }
    
}