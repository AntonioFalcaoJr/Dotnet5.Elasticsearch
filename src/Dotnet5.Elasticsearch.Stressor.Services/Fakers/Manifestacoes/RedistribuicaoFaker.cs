using System;
using System.Collections.Generic;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Manifestacoes
{
    public static class RedistribuicaoFaker
    {
        private static readonly IList<string> Situacoes = new List<string> {"Aceita", "Rejeitada", "Cancelada"};
        private static readonly IList<string> Tipos = new List<string> {"Definitiva", "Provisória"};

        public static readonly Faker<Redistribuicao> Redistribuicao =
            new Faker<Redistribuicao>()
               .RuleFor(x => x.Situacao, f => f.Random.ListItem(Situacoes))
               .RuleFor(x => x.Tipo, f => f.Random.ListItem(Tipos))
               .RuleFor(x => x.Id, f => Guid.NewGuid());
    }
}