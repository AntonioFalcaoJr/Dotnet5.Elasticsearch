using System;
using System.Collections.Generic;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes
{
    public class Manifestacao : Entity<Guid>
    {
        public Assessor Assessor { get; set; }
        public string Categoria { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public DateTime? Prazo { get; set; }
        public Redistribuicao Redistribuicao { get; set; }
        public Transferencia Transferencia { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}