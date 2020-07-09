using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities
{
    public class Documento : Entity<Guid>
    {
        public string Categoria { get; set; }
        public string Conteudo { get; set; }
        public string Situacao { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}