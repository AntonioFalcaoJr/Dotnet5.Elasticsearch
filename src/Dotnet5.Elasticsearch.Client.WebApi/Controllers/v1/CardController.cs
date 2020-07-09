using System;
using Dotnet5.Elasticsearch.Client.Services;
using Dotnet5.Elasticsearch.Client.WebApi.Controllers.Abstractions;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet5.Elasticsearch.Client.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class CardController : SyncClientControllerBase<Card, CardModel, Guid>
    {
        public CardController(ICardClientService cardClientService)
            : base(cardClientService) { }
    }
}