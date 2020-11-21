using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Stressor.Services.Clients;
using Dotnet5.Elasticsearch.Stressor.Services.Fakers;
using Microsoft.Extensions.Logging;

namespace Dotnet5.Elasticsearch.Stressor.Services
{
    public class StressorService : IStressorService
    {
        private readonly ICardClient _cardClient;
        private readonly ILogger<StressorService> _logger;

        public StressorService(ICardClient cardClient, ILogger<StressorService> logger)
        {
            _cardClient = cardClient;
            _logger = logger;
        }

        public async Task GenerateAsync(int amount, CancellationToken cancellationToken)
        {
            await foreach (var cards in GenerateFakeCardAsync(amount).WithCancellation(cancellationToken))
            {
                var result = await Task.WhenAll(cards.Select(card
                    => _cardClient.PostAsync(card, cancellationToken)));

                foreach (var cardModel in result.Where(x => x.IsValid is false))
                    _logger.LogError($"{cardModel.Card?.Notification?.Error} "
                                     + $"| {cardModel.Notification?.Error}");
            }

            _logger.LogInformation($"{amount} fake cards generated");
        }

        public Task ExcludeAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task ModifyAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

        private async IAsyncEnumerable<List<Card>> GenerateFakeCardAsync(int amount)
        {
            _logger.LogInformation($"Begin generate {amount} fake cards");
            for (var i = 0; i < amount; i++)
                yield return await Task.Factory.StartNew(()
                    => TarefaCardFaker.AtividadeCard.Generate(1));
        }
    }
}