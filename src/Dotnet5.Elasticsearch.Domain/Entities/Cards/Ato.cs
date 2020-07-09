using System;
using System.Collections.Generic;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards
{
    public class Ato : Entity<Guid>
    {
        public string AntecipacaoDoAto { get; set; }
        public DateTime DataDeRecebimento { get; set; }
        public string DescricaoDoTipoDeMovimentacao { get; set; }
        public ICollection<Manifestacao> Pendencias { get; set; }
        public string Teor { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}