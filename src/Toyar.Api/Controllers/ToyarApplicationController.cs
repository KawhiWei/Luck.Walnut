using Microsoft.AspNetCore.Mvc;
using Toyar.AppService.ToyarApplicationService;
using Toyar.Dto.ToyarApplications;
using Toyar.Query.ToyarApplicationQuery;

namespace Toyar.Api.Controllers;

[Route("api/toyarapplication")]
public class ToyarApplicationController : BaseController
{
    private readonly IToyarApplicationService _toyarApplicationService;
    private readonly IToyarApplicationQuery _toyarApplicationQuery;

    public ToyarApplicationController(
        IToyarApplicationService toyarApplicationService, 
        IToyarApplicationQuery toyarApplicationQuery)
    {
        _toyarApplicationService = toyarApplicationService;
        _toyarApplicationQuery = toyarApplicationQuery;
    }


    [HttpPost("add")]
    public Task AddToyarApplication([FromBody] ToyarCreateApplicationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationAsync(input);
    
    [HttpGet("{appId}/appId")]
    public Task<ToyarApplicationOutputDto> QueryToyarApplicationByAppId(string appId) =>
        _toyarApplicationQuery.QueryToyarApplicationByAppId(appId);

    [HttpDelete("{id}/delete")]
    public Task DeleteToyarApplication(string id) => _toyarApplicationService.DeleteToyarAppByIdAsync(id);


    [HttpPost("{appId}/add/permissionRelation")]
    public Task AddToyarApplicationPermissionRelation(string appId,
        [FromBody] ToyarApplicationPermissionRelationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationPermissionRelationAsync(appId, input);

    [HttpDelete("{appId}/delete/permissionRelation/{permissionId}")]
    public Task DeleteToyarApplicationPermissionRelation(string appId, string permissionId) =>
        _toyarApplicationService.DeleteToyarApplicationPermissionRelationAsync(permissionId, permissionId);


    [HttpDelete("{appId}/add/environmentRelation")]
    public Task AddToyarApplicationEnvironmentRelation(string appId,
        ToyarApplicationEnvironmentRelationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationEnvironmentRelationAsync(appId, input);

    [HttpPut("{appId}/update/deploymentConfiguration/{id}")]
    public Task UpdateToyarApplicationDeploymentConfiguration(string appId, string id,
        [FromBody] ToyarApplicationDeploymentConfigurationInputDto input) =>
        _toyarApplicationService.UpdateToyarApplicationDeploymentConfigurationAsync(appId, id, input);
}