using System;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Repositories.Abstractions;
using Dotnet5.Elasticsearch.Repositories.Abstractions.NoSqls;
using Microsoft.Extensions.Logging;
using Nest;

namespace Dotnet5.Elasticsearch.Repositories
{
    public class CardNoSqlRepository : NoSqlRepository<Card, Guid>, ICardNoSqlRepository
    {
        public CardNoSqlRepository(IElasticClient elasticClient, ILogger<NoSqlRepository<Card, Guid>> logger)
            : base(elasticClient, logger) { }
    }
}