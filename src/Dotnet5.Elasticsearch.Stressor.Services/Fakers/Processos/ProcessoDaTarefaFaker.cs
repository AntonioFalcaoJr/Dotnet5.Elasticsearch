using System;
using Bogus;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos;

namespace Dotnet5.Elasticsearch.Stressor.Services.Fakers.Processos
{
    public static class ProcessoDaTarefaFaker
    {
        public static readonly Faker<Processo> ProcessoDaTarefa =
            new Faker<Processo>()
               .RuleFor(x => x.NumeroJudicial,
                    f =>
                        $"{f.Random.Int(0, 9999999):0000000}-{f.Random.Short(0, 99):00}.{f.Random.Int(0, 9999):0000}.{f.Random.Int(0, 9):0}.{f.Random.Int(0, 99):00}.{f.Random.Int(0, 99999):00000}")
               .RuleFor(x => x.NumeroNoSaj, f => $"{f.Random.Int(0, 9999):0000}.{f.Random.Short(0, 99):00}.{f.Random.Int(0, 999999):000000}")
               .RuleFor(x => x.Area, f => f.Lorem.Word())
               .RuleFor(x => x.Assunto, f => f.Lorem.Sentence())
               .RuleFor(x => x.Classe, f => f.Lorem.Sentence(4))
               .RuleFor(x => x.Id, _ => Guid.NewGuid())
               .RuleFor(x => x.ParteAtiva, ParteDoProcessoDaTarefaFaker.ParteDoProcesso.Generate())
               .RuleFor(x => x.PartePassiva, ParteDoProcessoDaTarefaFaker.ParteDoProcesso.Generate());
    }
}