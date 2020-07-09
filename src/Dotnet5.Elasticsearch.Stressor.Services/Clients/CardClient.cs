using System;
using System.Net.Http;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Clients;
using Dotnet5.Elasticsearch.Stressor.Services.Clients.Base;

namespace Dotnet5.Elasticsearch.Stressor.Services.Clients
{
    internal class CardClient : Client<Card, CardClientModel, Guid>, ICardClient
    {
        public CardClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory) { }

        protected override string ClientName => "elasticsearch";
        protected override string DeleteEndpoint => "";
        protected override string GetEndpoint => "";
        protected override string PostEndpoint => "api/v1/card";
        protected override string PutEndpoint => "";
    }
}