using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Atos;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Domain.Models.Cards
{
    public class CardModel : Model<Guid>
    {
        public AtoModel Ato { get; set; }
        public ManifestacaoModel Manifestacao { get; set; }
        public ProcessoModel Processo { get; set; }
    }

    public class ProcessoModel { }
}