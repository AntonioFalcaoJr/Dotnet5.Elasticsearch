using System;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers
{
    public static class AtoDaTarefaFaker
    {
        public static readonly Faker<Ato> AtoDaTarefa =
            new Faker<Ato>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.DataDeRecebimento, f => f.Date.Between(f.Date.Past(), f.Date.Future()))
                .RuleFor(x => x.DescricaoDoTipoDeMovimentacao, f => f.Lorem.Sentence())
                .RuleFor(x => x.Titulo, f => f.Lorem.Sentence(4))
                .RuleFor(x => x.Pendencias, _ => ManifestacaoDaTarefaFaker.ManifestacaoDaTarefa.Generate(2))
                .RuleFor(x => x.Teor, f => f.Lorem.Paragraphs())
                .RuleFor(x => x.Tipo, f => f.Lorem.Word())
                .RuleFor(x => x.AntecipacaoDoAto, f => f.Lorem.Paragraph());
    }
}