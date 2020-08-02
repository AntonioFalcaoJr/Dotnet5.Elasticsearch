ARG ASPNET_VERSION="5.0-alpine"
ARG SDK_VERSION="5.0-alpine"

FROM mcr.microsoft.com/dotnet/core/aspnet:$ASPNET_VERSION AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/core/sdk:$SDK_VERSION AS build
WORKDIR /src

COPY ./src/Dotnet5.Elasticsearch.Domain/*.csproj ./Dotnet5.Elasticsearch.Domain/
COPY ./src/Dotnet5.Elasticsearch.CrossCutting/*.csproj ./Dotnet5.Elasticsearch.CrossCutting/
COPY ./src/Dotnet5.Elasticsearch.Services.Abstractions/*.csproj ./Dotnet5.Elasticsearch.Services.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Repositories/*.csproj ./Dotnet5.Elasticsearch.Repositories/
COPY ./src/Dotnet5.Elasticsearch.Repositories.Abstractions/*.csproj ./Dotnet5.Elasticsearch.Repositories.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Infrastructure/*.csproj ./Dotnet5.Elasticsearch.Infrastructure/

COPY ./src/Dotnet5.Elasticsearch.Client.Services/*.csproj ./Dotnet5.Elasticsearch.Client.Services/
COPY ./src/Dotnet5.Elasticsearch.Client.WebApi/*.csproj ./Dotnet5.Elasticsearch.Client.WebApi/

COPY ./NuGet.Config ./
RUN dotnet restore ./Dotnet5.Elasticsearch.Client.WebApi

COPY ./src/Dotnet5.Elasticsearch.Domain/. ./Dotnet5.Elasticsearch.Domain/
COPY ./src/Dotnet5.Elasticsearch.CrossCutting/. ./Dotnet5.Elasticsearch.CrossCutting/
COPY ./src/Dotnet5.Elasticsearch.Services.Abstractions/. ./Dotnet5.Elasticsearch.Services.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Repositories/. ./Dotnet5.Elasticsearch.Repositories/
COPY ./src/Dotnet5.Elasticsearch.Repositories.Abstractions/. ./Dotnet5.Elasticsearch.Repositories.Abstractions/
COPY ./src/Dotnet5.Elasticsearch.Infrastructure/. ./Dotnet5.Elasticsearch.Infrastructure/

COPY ./src/Dotnet5.Elasticsearch.Client.Services/. ./Dotnet5.Elasticsearch.Client.Services/
COPY ./src/Dotnet5.Elasticsearch.Client.WebApi/. ./Dotnet5.Elasticsearch.Client.WebApi/

WORKDIR /src/Dotnet5.Elasticsearch.Client.WebApi
RUN dotnet build -c Release --no-restore -o /app/build 

FROM build AS publish
RUN dotnet publish -c Release --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet5.Elasticsearch.Client.WebApi.dll"]
