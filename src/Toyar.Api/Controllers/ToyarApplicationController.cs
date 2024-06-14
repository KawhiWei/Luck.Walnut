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


    [HttpPost]
    public Task AddToyarApplication([FromBody] ToyarApplicationInputDto input) =>
        _toyarApplicationService.CreateToyarApplicationAsync(input);


    [HttpPost("{appId}/add/toyarApplication/permissionRelation")]
    public Task AddToyarApplicationUserRelation(string appId,
        [FromBody] ToyarApplicationPermissionRelationInputDto input) =>
        _toyarApplicationService.AddToyarApplicationUserRelationAsync(appId, input);

    [HttpDelete("{appId}/delete/toyarApplication/permissionRelation/{permissionId}")]
    public Task AddToyarApplicationEnvironmentRelation(string appId, string permissionId) =>
        _toyarApplicationService.DeleteToyarApplicationPermissionRelationAsync(permissionId, permissionId);
}