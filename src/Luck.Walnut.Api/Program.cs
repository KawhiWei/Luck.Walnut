using System.Text.Json.Serialization;
using Hoyo.WebCore;
using Luck.AspNetCore;
using Luck.Framework.Infrastructure;
using Luck.Framework.Threading;
using Luck.Walnut.Api.AppModules;
using Luck.Walnut.Api.GrpcServices;
using Luck.Walnut.Application.BackgroundServices;
using Luck.WebSocket.Server;
using Luck.WebSocket.Server.Extensions;
using MediatR;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// builder.WebHost.ConfigureKestrel(x 
//     =>
// {
//     // x.ListenAnyIP(5094, opt => opt.Protocols = HttpProtocols.Http2);
//     x.ListenAnyIP(5099, opt => opt.Protocols = HttpProtocols.Http1);
//     x.ListenAnyIP(5264, opt => opt.Protocols = HttpProtocols.Http2);
// }
//     );


// Add services to the container.
builder.Services.AddApplication<AppWebModule>();

builder.Services.AddControllers()
    .AddJsonOptions(c =>
    {
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.TimeOnlyJsonConverter());
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateOnlyJsonConverter());
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.TimeOnlyNullJsonConverter());
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateOnlyNullJsonConverter());
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeConverter());
    });

builder.Services.AddGrpc();

builder.Services.AddWebSocketConfigRouterEndpoint(x =>
{
    x.WebSocketChannels = new Dictionary<string, WebSocketRouteOption.WebSocketChannelHandler>()
    {
        { "/im", new MvcChannelHandler(4 * 1024).ConnectionEntry }
    };
    x.ApplicationServiceCollection = builder.Services;
});

builder.Services.AddMediatR(AssemblyHelper.AllAssemblies);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICancellationTokenProvider, HttpContextCancellationTokenProvider>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
var test = Environment.GetEnvironmentVariable("AppId");
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Services.AddHostedService<JenkinsExecutedRecordSyncBackgroundService>();
// builder.Services.AddOpenTelemetryTracing(b =>
// {
//     b.AddConsoleExporter()
//         .AddSource(test)
//         .SetResourceBuilder(ResourceBuilder.CreateDefault()
//             .AddService(serviceName: test, serviceVersion: "1.0.0"))
//         .AddAspNetCoreInstrumentation();
//     // The rest of your setup code goes here too
// })
//     .AddOpenTelemetryMetrics(x =>
// {
//     var a = ResourceBuilder.CreateDefault()
//         .AddService(serviceName: test, serviceVersion: "1.0.0");
//     x.SetResourceBuilder(a)
//         .AddHttpClientInstrumentation()
//         .AddAspNetCoreInstrumentation();
//     x.AddConsoleExporter();
// })
//     ;

var app = builder.Build();
app.UsePathBase("/walnut");

#region WebSocket

var webSocketOptions = new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(15), //服务的主动向客户端发起心跳检测时间
    // ReceiveBufferSize = 4 * 1024 //数据缓冲区
};
app.UseWebSockets(webSocketOptions);
app.UseWebSocketServer(app.Services);

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseAuthorization();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GetConfigService>();
    endpoints.MapGrpcService<LuCatGrpcService>();
});


app.MapControllers();
app.InitializeApplication();
app.Run();


public partial class Program
{
}