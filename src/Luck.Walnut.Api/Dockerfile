FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Luck.Walnut.Api/Luck.Walnut.Api.csproj", "Luck.Walnut.Api/"]
COPY ["src/Luck.Walnut.Application/Luck.Walnut.Application.csproj", "Luck.Walnut.Application/"]
COPY ["src/Luck.Walnut.Adapter/Luck.Walnut.Adapter.csproj", "Luck.Walnut.Adapter/"]
COPY ["src/Luck.Walnut.Domain/Luck.Walnut.Domain.csproj", "Luck.Walnut.Domain/"]
COPY ["src/Luck.Walnut.Domain.Shared/Luck.Walnut.Domain.Shared.csproj", "Luck.Walnut.Domain.Shared/"]
COPY ["src/Luck.Walnut.Dto/Luck.Walnut.Dto.csproj", "Luck.Walnut.Dto/"]
COPY ["src/Luck.Walnut.Infrastructure/Luck.Walnut.Infrastructure.csproj", "Luck.Walnut.Infrastructure/"]
COPY ["src/Luck.Walnut.Persistence/Luck.Walnut.Persistence.csproj", "Luck.Walnut.Persistence/"]
COPY ["src/Luck.Walnut.Query/Luck.Walnut.Query.csproj", "Luck.Walnut.Query/"]
RUN dotnet restore "src/Luck.Walnut.Api/Luck.Walnut.Api.csproj"
COPY . .
WORKDIR "/src/Luck.Walnut.Api"
RUN dotnet build "Luck.Walnut.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luck.Walnut.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luck.Walnut.Api.dll"]
