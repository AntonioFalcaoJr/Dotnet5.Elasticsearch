using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos
{
    public class Parte : Entity<Guid>
    {
        public string Nome { get; set; }

        protected override void SetId(Guid id) => Id = id;
    }
}