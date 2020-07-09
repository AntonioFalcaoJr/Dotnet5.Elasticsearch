using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards
{
    public class Card : Entity<Guid>
    {
        public Ato Ato { get; set; }
        public Manifestacao Manifestacao { get; set; }
        public Processo Processo { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}