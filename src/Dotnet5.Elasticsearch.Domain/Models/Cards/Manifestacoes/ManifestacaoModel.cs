using System;
using System.Collections.Generic;

namespace Dotnet5.Elasticsearch.Domain.Models.Cards.Manifestacoes
{
    public class ManifestacaoModel
    {
        public AssessorModel Assessor { get; set; }
        public string Categoria { get; set; }
        public ICollection<DocumentoModel> Documentos { get; set; }
        public ICollection<PedidoModel> Pedidos { get; set; }
        public DateTime? Prazo { get; set; }
        public RedistribuicaoModel Redistribuicao { get; set; }
        public TransferenciaModel Transferencia { get; set; }
    }
}