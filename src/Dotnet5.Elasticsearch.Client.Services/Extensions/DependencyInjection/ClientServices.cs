using AutoMapper;
using Dotnet5.Elasticsearch.Client.Services.Profiles;
using Dotnet5.Elasticsearch.Client.Services.Profiles.Atos;
using Dotnet5.Elasticsearch.Client.Services.Profiles.Manifestacoes;
using Dotnet5.Elasticsearch.Client.Services.Profiles.Processos;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.Elasticsearch.Client.Services.Extensions.DependencyInjection
{
    public static class ClientServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(CardProfile), typeof(ManifestacaoProfile), typeof(ProcessoProfile), typeof(AtoProfile));

        public static IServiceCollection AddClientServices(this IServiceCollection services)
            => services.AddScoped<ICardClientService, CardClientService>();
    }
}