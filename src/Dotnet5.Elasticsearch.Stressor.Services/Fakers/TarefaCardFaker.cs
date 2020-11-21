using System;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes;
using Dotnet5.Elasticsearch.Stressor.Services.Fakers.Processos;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers
{
    public static class TarefaCardFaker
    {
        public static readonly Faker<Card> AtividadeCard =
            new Faker<Card>()
               .RuleFor(x => x.Id, _ => Guid.NewGuid())
               .RuleFor(x => x.Ato, _ => AtoDaTarefaFaker.AtoDaTarefa.Generate())
               .RuleFor(x => x.Manifestacao, _ => ManifestacaoDaTarefaFaker.ManifestacaoDaTarefa.Generate())
               .RuleFor(x => x.Processo, _ => ProcessoDaTarefaFaker.ProcessoDaTarefa.Generate());
    }
}