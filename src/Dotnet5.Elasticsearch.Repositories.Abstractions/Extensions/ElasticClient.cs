using Elasticsearch.Net;
using Microsoft.Extensions.Logging;
using Nest;

namespace Dotnet5.Elasticsearch.Repositories.Abstractions.Extensions
{
    internal static class ElasticClient
    {
        public static void LogResponse(this ILogger logger, IElasticsearchResponse response)
        {
            var responseBase = response as ResponseBase;
            if (responseBase?.IsValid ?? true) return;
            logger.LogError(responseBase.ServerError?.Error.ToString()
                ?? responseBase.ApiCall?.DebugInformation);
        }
    }
}