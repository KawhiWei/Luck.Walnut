using Grpc.Core;
using Toyar.App.AppService.Environments;
using Toyar.App.Query.Environments;
using Toyar.App.V1;

namespace Toyar.App.Api.GrpcServices
{
    public class GetConfigService : GetConfig.GetConfigBase
    {
        private readonly IEnvironmentQueryService _environmentQueryService;

        public GetConfigService(IEnvironmentQueryService environmentQueryService)
        {
            _environmentQueryService = environmentQueryService;
        }

        public override async Task<ApplicationConfigResponse> GetAppliactionConfig(ApplicationConfigRequest request, ServerCallContext context)
        {
            var configs = await _environmentQueryService.GetAppConfigurationByAppIdAndEnvironmentNameAsync(request.AppId, request.EnvironmentName);
                        var response = new ApplicationConfigResponse();
            
            
            
            
            return response;
        }
    }
}
