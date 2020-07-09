using System;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Clients;
using Dotnet5.Elasticsearch.Stressor.Services.Clients.Base;

namespace Dotnet5.Elasticsearch.Stressor.Services.Clients
{
    public interface ICardClient : IClient<Card, CardClientModel, Guid> { }
}