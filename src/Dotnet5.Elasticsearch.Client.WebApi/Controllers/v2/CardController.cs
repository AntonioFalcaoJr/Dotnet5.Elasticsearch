using System;
using Dotnet5.Elasticsearch.Client.Services;
using Dotnet5.Elasticsearch.Client.WebApi.Controllers.Abstractions;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Client.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    public class CardController : AsyncClientControllerBase<Card, CardModel, Guid>
    {
        public CardController(ICardClientService cardClientService)
            : base(cardClientService) { }
    }
}