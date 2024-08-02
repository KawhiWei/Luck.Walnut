using Luck.AspNetCore;
using Luck.Framework.Infrastructure;
using Luck.Framework.Threading;
using Luck.WebSocket.Server;
using Luck.WebSocket.Server.Extensions;
using MediatR;
using Luck.AppModule;
using Luck.AutoDependencyInjection;
using Toyar.Api.AppModules;
using Toyar.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication<AppWebModule>();

builder.Services.AddControllers()
    .AddJsonOptions(c =>
    {
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeOffsetConverter());
        c.JsonSerializerOptions.Converters.Add(new SystemTextJsonConvert.DateTimeOffsetNullConverter());
    });

builder.Services.AddWebSocketConfigRouterEndpoint(x =>
{
    x.WebSocketChannels = new Dictionary<string, WebSocketRouteOption.WebSocketChannelHandler>()
    {
        { "/im", new MvcChannelHandler(4 * 1024).ConnectionEntry }
    };
    x.ApplicationServiceCollection = builder.Services;
});
var configuration = builder.Services.GetConfiguration();
builder.Services.Configure<ToyarConfig>(configuration.GetSection("ToyarConfig"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICancellationTokenProvider, HttpContextCancellationTokenProvider>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();

//builder.Services.AddHostedService<JenkinsExecutedRecordSyncBackgroundService>();

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

app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();
app.MapControllers();
app.InitializeApplication();
app.Run();
