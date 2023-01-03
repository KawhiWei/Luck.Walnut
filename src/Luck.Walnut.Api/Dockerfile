#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Luck.Walnut.Api/Luck.Walnut.Api.csproj", "src/Luck.Walnut.Api/"]
COPY ["src/Luck.Walnut.Application/Luck.Walnut.Application.csproj", "src/Luck.Walnut.Application/"]
COPY ["src/Luck.Walnut.Adapter/Luck.Walnut.Adapter.csproj", "src/Luck.Walnut.Adapter/"]
COPY ["src/Luck.Walnut.Domain/Luck.Walnut.Domain.csproj", "src/Luck.Walnut.Domain/"]
COPY ["src/Luck.Walnut.Domain.Shared/Luck.Walnut.Domain.Shared.csproj", "src/Luck.Walnut.Domain.Shared/"]
COPY ["src/Luck.Walnut.Dto/Luck.Walnut.Dto.csproj", "src/Luck.Walnut.Dto/"]
COPY ["src/Luck.Walnut.Infrastructure/Luck.Walnut.Infrastructure.csproj", "src/Luck.Walnut.Infrastructure/"]
COPY ["src/Luck.Walnut.Persistence/Luck.Walnut.Persistence.csproj", "src/Luck.Walnut.Persistence/"]
COPY ["src/Luck.Walnut.Query/Luck.Walnut.Query.csproj", "src/Luck.Walnut.Query/"]
RUN dotnet restore "src/Luck.Walnut.Api/Luck.Walnut.Api.csproj"
COPY . .
WORKDIR "/src/src/Luck.Walnut.Api"
RUN dotnet build "Luck.Walnut.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luck.Walnut.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luck.Walnut.Api.dll"]