using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards;
using Dotnet5.Elasticsearch.Repositories.Abstractions;
using Dotnet5.Elasticsearch.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Dotnet5.Elasticsearch.Client.Services
{
    public class CardClientService : Service<Card, CardModel, Guid>, ICardClientService
    {
        private readonly ILogger<CardClientService> _logger;

        public CardClientService(ICardNoSqlRepository repository, IMapper mapper, ILogger<CardClientService> logger)
            : base(repository, mapper)
        {
            _logger = logger;
        }

        public override void Delete(Guid id)
        {
            OnDelete(id);
            _logger.LogInformation($"Deleted document {id}");
        }

        public override async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await OnDeleteAsync(id, cancellationToken);
            _logger.LogInformation($"Deleted document {id}");
        }

        public override bool Exists(Guid id)
        {
            var exists = OnExists(id);
            _logger.LogInformation($"Verified document {id}, exists: {exists}");
            return exists;
        }

        public override async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
        {
            var exists = await OnExistsAsync(id, cancellationToken);
            _logger.LogInformation($"Verified document {id}, exists: {exists}");
            return exists;
        }

        public override IEnumerable<Card> GetAll(Expression<Func<Card, bool>> predicate = default)
        {
            var cards = OnGetAll(predicate);
            if (cards?.Any() is false) return default;
            _logger.LogInformation($"Restored {cards.Count()} documents");
            return cards;
        }

        public override async Task<IEnumerable<Card>> GetAllAsync(CancellationToken cancellationToken,
            Expression<Func<Card, bool>> predicate = default)
        {
            var cards = await OnGetAllAsync(cancellationToken, predicate);
            if (cards?.Any() is false) return default;
            _logger.LogInformation($"Restored {cards.Count()} documents");
            return cards;
        }

        public override Card GetById(Guid id)
        {
            var card = OnGetById(id);
            if (card is null) return default;
            _logger.LogInformation($"Restored document {card.Id}");
            return card;
        }

        public override async Task<Card> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var card = await OnGetByIdAsync(id, cancellationToken);
            if (card is null) return default;
            _logger.LogInformation($"Restored document {card.Id}");
            return card;
        }

        public override Card Save(CardModel model)
        {
            if (model is null) return default;
            var card = OnSave(model);
            _logger.LogInformation($"Indexed document {card.Id}");
            return card;
        }

        public override async Task<Card> SaveAsync(CardModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var card = await OnSaveAsync(model, cancellationToken);
            _logger.LogInformation($"Indexed document {card.Id}");
            return card;
        }

        public override Card Edit(CardModel model)
        {
            if (model is null) return default;
            var card = OnEdit(model);
            _logger.LogInformation($"Updated document {card.Id}");
            return card;
        }

        public override async Task<Card> EditAsync(CardModel model, CancellationToken cancellationToken)
        {
            if (model is null) return default;
            var card = await OnEditAsync(model, cancellationToken);
            _logger.LogInformation($"Updated document {card.Id}");
            return card;
        }
    }
}