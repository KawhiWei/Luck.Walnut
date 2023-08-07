#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/luck-net/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM registry.cn-hangzhou.aliyuncs.com/luck-net/aspnet-sdk:6.0 AS build
WORKDIR /src
COPY ["src/Toyar.App.Api/Toyar.App.Api.csproj", "src/Toyar.App.Api/"]
COPY ["src/Toyar.App.AppService/Toyar.App.AppService.csproj", "src/Toyar.App.AppService/"]
COPY ["src/Toyar.App.Adapter/Toyar.App.Adapter.csproj", "src/Toyar.App.Adapter/"]
COPY ["src/Toyar.App.Domain/Toyar.App.Domain.csproj", "src/Toyar.App.Domain/"]
COPY ["src/Toyar.App.Domain.Shared/Toyar.App.Domain.Shared.csproj", "src/Toyar.App.Domain.Shared/"]
COPY ["src/Toyar.App.Dto/Toyar.App.Dto.csproj", "src/Toyar.App.Dto/"]
COPY ["src/Toyar.App.Infrastructure/Toyar.App.Infrastructure.csproj", "src/Toyar.App.Infrastructure/"]
COPY ["src/Toyar.App.Persistence/Toyar.App.Persistence.csproj", "src/Toyar.App.Persistence/"]
COPY ["src/Toyar.App.Query/Toyar.App.Query.csproj", "src/Toyar.App.Query/"]
RUN dotnet restore --source https://nuget.cdn.azure.cn/v3/index.json "src/Toyar.App.Api/Toyar.App.Api.csproj"
COPY . .
WORKDIR "/src/src/Toyar.App.Api"
RUN dotnet build "Toyar.App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Toyar.App.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "Toyar.App.Api.dll"]