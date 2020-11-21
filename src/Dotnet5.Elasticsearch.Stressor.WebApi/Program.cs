using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.Elasticsearch.Stressor.WebApi
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2000);
                        options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(2000);
                    });
                });

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
    }
}