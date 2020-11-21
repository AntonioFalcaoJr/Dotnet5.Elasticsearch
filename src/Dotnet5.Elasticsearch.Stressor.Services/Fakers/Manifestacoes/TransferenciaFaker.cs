using System;
using System.Collections.Generic;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes
{
    public static class TransferenciaFaker
    {
        private static readonly IList<string> Situacoes = new List<string> {"Aceita", "Rejeitada", "Cancelada"};

        public static readonly Faker<Transferencia> Transferencia =
            new Faker<Transferencia>()
                .RuleFor(x => x.Situacao, f => f.Random.ListItem(Situacoes))
                .RuleFor(x => x.Id, _ => Guid.NewGuid());
    }
}