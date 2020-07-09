using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes
{
    public static class PedidoDaManifestacaoFaker
    {
        public static readonly Faker<Pedido> PedidoDaManifestacao =
            new Faker<Pedido>()
               .RuleFor(x => x.DocumentoDeSolicitacao, f => DocumentoFaker.Documento.Generate())
               .RuleFor(x => x.DocumentoDeResposta, f => DocumentoFaker.Documento.Generate());
    }
}