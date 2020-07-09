using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;

namespace Dotnet5.Elasticsearch.Domain.Models.Clients
{
    public class CardClientModel : ClientModel<Guid>
    {
        public Card Card { get; set; }
    }
}