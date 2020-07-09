using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes
{
    public class Redistribuicao : Entity<Guid>
    {
        public string Situacao { get; set; }
        public string Tipo { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}