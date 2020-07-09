using System;
using System.Collections.Generic;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Domain.Models.Cards.Atos
{
    public class AtoModel
    {
        public string AntecipacaoDoAto { get; set; }
        public DateTime DataDeRecebimento { get; set; }
        public string DescricaoDoTipoDeMovimentacao { get; set; }
        public ICollection<ManifestacaoModel> Pendencias { get; set; }
        public string Teor { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
    }
}