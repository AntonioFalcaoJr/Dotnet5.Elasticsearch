using System;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards;
using Dotnet5.Elasticsearch.Services.Abstractions;

namespace Dotnet5.Elasticsearch.Client.Services
{
    public interface ICardClientService : IService<Card, CardModel, Guid> { }
}