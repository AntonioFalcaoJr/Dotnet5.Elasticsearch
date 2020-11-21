using System;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Processos
{
    public static class ParteDoProcessoDaTarefaFaker
    {
        public static readonly Faker<Parte> ParteDoProcesso =
            new Faker<Parte>()
                .RuleFor(x => x.Id, _ => Guid.NewGuid())
                .RuleFor(x => x.Nome, f => f.Name.FullName());
    }
}