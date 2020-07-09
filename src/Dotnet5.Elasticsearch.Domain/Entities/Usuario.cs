using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities
{
    public abstract class Usuario : Entity<Guid>
    {
        public bool Ativo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}