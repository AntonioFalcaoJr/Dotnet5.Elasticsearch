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
               .RuleFor(x => x.Id, f => Guid.NewGuid())
               .RuleFor(x => x.Ato, f => AtoDaTarefaFaker.AtoDaTarefa.Generate())
               .RuleFor(x => x.Manifestacao, f => ManifestacaoDaTarefaFaker.ManifestacaoDaTarefa.Generate())
               .RuleFor(x => x.Processo, f => ProcessoDaTarefaFaker.ProcessoDaTarefa.Generate());
    }
}