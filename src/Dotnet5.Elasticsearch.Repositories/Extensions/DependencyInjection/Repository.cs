using Dotnet5.Elasticsearch.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.Elasticsearch.Repositories.Extensions.DependencyInjection
{
    public static class Repository
    {
        public static IServiceCollection AddNoSqlRepositories(this IServiceCollection services)
            => services.AddScoped<ICardNoSqlRepository, CardNoSqlRepository>();
    }
}