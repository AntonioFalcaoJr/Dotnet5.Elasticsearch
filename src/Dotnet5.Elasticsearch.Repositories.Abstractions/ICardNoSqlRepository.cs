using System;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Repositories.Abstractions.NoSqls;

namespace Dotnet5.Elasticsearch.Repositories.Abstractions
{
    public interface ICardNoSqlRepository : INoSqlRepository<Card, Guid> { }
}