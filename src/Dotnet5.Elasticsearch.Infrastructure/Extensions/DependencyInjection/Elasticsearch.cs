using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nest;
using Polly;
using Polly.Extensions.Http;

namespace Dotnet5.Elasticsearch.Infrastructure.Extensions.DependencyInjection
{
    public static class Elasticsearch
    {
        private const int RetryAttempt = 10;
        private const int CircuitBreakAttempt = 5;
        private static readonly Options Options = new Options();
        private static readonly TimeSpan DurationOfCircuitBreak = TimeSpan.FromSeconds(15);

        public static void AddElasticsearchService(this IServiceCollection services, Action<Options> optionsAction)
        {
            optionsAction.Invoke(Options);

            var settings = new ConnectionSettings(Options.Uri)
               .DefaultIndex(Options.Index)
               .RequestTimeout(TimeSpan.FromMinutes(120));

            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddResilientElasticsearchClient(this IServiceCollection services, Action<Options> optionsAction)
        {
            optionsAction.Invoke(Options);

            services.AddHttpClient("elasticsearch", client => client.BaseAddress = Options.Uri)
               .AddPolicyHandler((provider, _) => GetRetryPolicy(provider))
               .AddPolicyHandler(GetCircuitBreakerPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
            => HttpPolicyExtensions.HandleTransientHttpError().CircuitBreakerAsync(CircuitBreakAttempt, DurationOfCircuitBreak);

        private static HttpStatusCode[] GetHttpStatusCodesWorthRetrying()
            => new[]
            {
                HttpStatusCode.NotFound,
                HttpStatusCode.BadGateway,
                HttpStatusCode.BadRequest,
                HttpStatusCode.GatewayTimeout,
                HttpStatusCode.RequestTimeout,
                HttpStatusCode.ServiceUnavailable,
                HttpStatusCode.InternalServerError
            };

        private static string GetRetryMessage(TimeSpan timeSpan, int attempt, DelegateResult<HttpResponseMessage> result)
        {
            var message = $"Waiting for {timeSpan.TotalMilliseconds}ms, "
                + $"then making retry {attempt}/{RetryAttempt}. "
                + $"Reason: {result.Exception.Message} ";

            return result.Result is null ? message : message + $"StatusCode: {result.Result?.StatusCode}";
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IServiceProvider provider)
            => HttpPolicyExtensions.HandleTransientHttpError()
               .OrResult(httpResponseMessage => GetHttpStatusCodesWorthRetrying().Contains(httpResponseMessage.StatusCode))
               .WaitAndRetryAsync(RetryAttempt, retryAttempt
                    => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (result, timeSpan, attempt, context)
                    => provider.GetService<ILogger<IElasticClient>>().LogWarning(GetRetryMessage(timeSpan, attempt, result)));
    }
}