using System;
using System.Collections.Generic;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes
{
    public static class ManifestacaoDaTarefaFaker
    {
        private static readonly IList<string> Categorias = new List<string> {"Movimentação", "Audiência"};

        public static readonly Faker<Manifestacao> ManifestacaoDaTarefa =
            new Faker<Manifestacao>()
                .RuleFor(x => x.Prazo, f => f.Date.Between(f.Date.Past(), f.Date.Future()))
                .RuleFor(x => x.Categoria, f => f.Random.ListItem(Categorias))
                .RuleFor(x => x.Assessor, _ => AssessorDaManifestacaoFaker.AssessorDaManifestacao.Generate())
                .RuleFor(x => x.Pedidos, _ => PedidoDaManifestacaoFaker.PedidoDaManifestacao.Generate(2))
                .RuleFor(x => x.Documentos, _ => DocumentoFaker.Documento.Generate(3))
                .RuleFor(x => x.Redistribuicao, _ => RedistribuicaoFaker.Redistribuicao.Generate())
                .RuleFor(x => x.Transferencia, _ => TransferenciaFaker.Transferencia.Generate())
                .RuleFor(x => x.Id, _ => Guid.NewGuid());
    }
}