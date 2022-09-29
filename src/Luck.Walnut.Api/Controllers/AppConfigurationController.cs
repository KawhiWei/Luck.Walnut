using Luck.Walnut.Application.Applications;
using Luck.Walnut.Domain.Repositories;
using Luck.Walnut.Dto;
using Luck.Walnut.Dto.Applications;
using Microsoft.AspNetCore.Mvc;

namespace Luck.Walnut.Api.Controllers;

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