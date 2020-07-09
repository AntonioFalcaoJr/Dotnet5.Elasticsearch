using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes
{
    public class Pedido : Entity<Guid>
    {
        public Documento DocumentoDeResposta { get; set; }
        public Documento DocumentoDeSolicitacao { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}