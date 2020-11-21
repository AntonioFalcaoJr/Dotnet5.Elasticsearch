using System;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes
{
    public static class AssessorDaManifestacaoFaker
    {
        public static readonly Faker<Assessor> AssessorDaManifestacao = new Faker<Assessor>()
            .RuleFor(x => x.Ativo, f => f.Random.Bool())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Nome, f => f.Name.FullName())
            .RuleFor(x => x.DataDeNascimento, f => f.Person.DateOfBirth)
            .RuleFor(x => x.Id, _ => Guid.NewGuid());
    }
}