using Dotnet5.Elasticsearch.Stressor.Services.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.Elasticsearch.Stressor.Services.Extensions.DependencyInjection
{
    public static class StressorServices
    {
        public static void AddServices(this IServiceCollection services)
            => services.AddScoped<ICardClient, CardClient>()
               .AddScoped<IStressorService, StressorService>();
    }
}