using System;
using System.Collections.Generic;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers
{
    public static class DocumentoFaker
    {
        private static readonly IList<string> Categorias = new List<string> {"Movimentação", "Audiência"};
        private static readonly IList<string> Situacoes = new List<string> {"Emitido", "Em andamento", "Protocolado"};

        public static readonly Faker<Documento> Documento =
            new Faker<Documento>()
               .RuleFor(x => x.Id, f => Guid.NewGuid())
               .RuleFor(x => x.Conteudo, f => f.Lorem.Sentence(50))
               .RuleFor(x => x.Categoria, f => f.Random.ListItem(Categorias))
               .RuleFor(x => x.Situacao, f => f.Random.ListItem(Situacoes));
    }
}