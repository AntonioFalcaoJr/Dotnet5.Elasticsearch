ARG ASPNET_VERSION="5.0-alpine"
ARG SDK_VERSION="5.0-alpine"

FROM mcr.microsoft.com/dotnet/core/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 6000

ENV ASPNETCORE_URLS=http://*:6000
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/core/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.Elasticsearch.Domain/*.csproj ./Dotnet5.Elasticsearch.Domain/
COPY ./src/Dotnet5.Elasticsearch.CrossCutting/*.csproj ./Dotnet5.Elasticsearch.CrossCutting/
COPY ./src/Dotnet5.Elasticsearch.Services.Abstractions/*.csproj ./Dotnet5.Elasticsearch.Stressor.Services.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Repositories/*.csproj ./Dotnet5.Elasticsearch.Repositories/
COPY ./src/Dotnet5.Elasticsearch.Repositories.Abstractions/*.csproj ./Dotnet5.Elasticsearch.Repositories.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Infrastructure/*.csproj ./Dotnet5.Elasticsearch.Infrastructure/

COPY ./src/Dotnet5.Elasticsearch.Stressor.Services/*.csproj ./Dotnet5.Elasticsearch.Stressor.Services/
COPY ./src/Dotnet5.Elasticsearch.Stressor.WebApi/*.csproj ./Dotnet5.Elasticsearch.Stressor.WebApi/

COPY ./NuGet.Config ./
RUN dotnet restore ./Dotnet5.Elasticsearch.Stressor.WebApi

COPY ./src/Dotnet5.Elasticsearch.Domain/. ./Dotnet5.Elasticsearch.Domain/
COPY ./src/Dotnet5.Elasticsearch.CrossCutting/. ./Dotnet5.Elasticsearch.CrossCutting/
COPY ./src/Dotnet5.Elasticsearch.Services.Abstractions/. ./Dotnet5.Elasticsearch.Services/
COPY ./src/Dotnet5.Elasticsearch.Repositories/. ./Dotnet5.Elasticsearch.Repositories/
COPY ./src/Dotnet5.Elasticsearch.Repositories.Abstractions/. ./Dotnet5.Elasticsearch.Repositories.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Infrastructure/. ./Dotnet5.Elasticsearch.Infrastructure/

COPY ./src/Dotnet5.Elasticsearch.Stressor.Services/. ./Dotnet5.Elasticsearch.Stressor.Services/
COPY ./src/Dotnet5.Elasticsearch.Stressor.WebApi/. ./Dotnet5.Elasticsearch.Stressor.WebApi/

WORKDIR /src/Dotnet5.Elasticsearch.Stressor.WebApi/
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.Elasticsearch.Stressor.WebApi.dll"]