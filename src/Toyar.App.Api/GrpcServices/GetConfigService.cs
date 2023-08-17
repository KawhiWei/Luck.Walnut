using Grpc.Core;
using Toyar.App.AppService.Environments;
using Toyar.App.Query.Environments;
using Toyar.App.V1;

namespace Toyar.App.Api.GrpcServices
{
    public class GetConfigService : GetConfig.GetConfigBase
    {
        private readonly IToyarEnvironmentQueryService _environmentQueryService;

        public GetConfigService(IToyarEnvironmentQueryService environmentQueryService)
        {
            _environmentQueryService = environmentQueryService;
        }

        public override async Task<ApplicationConfigResponse> GetAppliactionConfig(ApplicationConfigRequest request, ServerCallContext context)
        {
            await Task.CompletedTask;
            return new ApplicationConfigResponse();
        }
    }
}
