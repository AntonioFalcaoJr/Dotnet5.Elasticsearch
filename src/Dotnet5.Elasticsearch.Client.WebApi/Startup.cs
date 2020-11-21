using System;
using System.Text.Json.Serialization;
using Dotnet5.Elasticsearch.Client.Services.Extensions.DependencyInjection;
using Dotnet5.Elasticsearch.Infrastructure.Extensions.DependencyInjection;
using Dotnet5.Elasticsearch.Repositories.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.Elasticsearch.Client.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = false;
                });

            services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false);

            services.AddElasticsearchService(options =>
            {
                options.Index = Configuration["Elasticsearch:index"];
                options.Uri = new Uri(Configuration["Elasticsearch:node1Uri"]);
            });

            services.AddClientServices();
            services.AddNoSqlRepositories();
            services.AddAutoMapper();
            services.AddLogging();
        }
    }
}