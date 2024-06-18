using Microsoft.AspNetCore.Mvc;
using Toyar.AppService.ToyarAppService;
using Toyar.Dto.ToyarApps;

namespace Toyar.Api.Controllers;

[Route("api/toyarapplication")]
public class ToyarApplicationController : BaseController
{
    private readonly IToyarApplicationService _toyarApplicationService;

    public ToyarApplicationController(IToyarApplicationService toyarApplicationService)
    {
        _toyarApplicationService = toyarApplicationService;
    }


    [HttpPost("add/toyarApplication")]
    public Task AddToyarApplication([FromBody] ToyarApplicationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationAsync(input);

    [HttpDelete("{id}/delete/toyarApplication")]
    public Task DeleteToyarApplication(string id) => _toyarApplicationService.DeleteToyarAppByIdAsync(id);


    [HttpPost("{appId}/add/toyarApplication/permissionRelation")]
    public Task AddToyarApplicationPermissionRelation(string appId,
        [FromBody] ToyarApplicationPermissionRelationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationPermissionRelationAsync(appId, input);

    [HttpDelete("{appId}/delete/toyarApplication/permissionRelation/{permissionId}")]
    public Task DeleteToyarApplicationPermissionRelation(string appId, string permissionId) =>
        _toyarApplicationService.DeleteToyarApplicationPermissionRelationAsync(permissionId, permissionId);


    [HttpDelete("{appId}/add/toyarApplication/environmentRelation")]
    public Task AddToyarApplicationEnvironmentRelation(string appId,
        ToyarApplicationEnvironmentRelationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationEnvironmentRelationAsync(appId, input);
}