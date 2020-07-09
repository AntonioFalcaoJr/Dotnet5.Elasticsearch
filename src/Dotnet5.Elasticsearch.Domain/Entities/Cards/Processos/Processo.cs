using System;
using Dotnet5.Elasticsearch.Domain.Abstractions;

namespace Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos
{
    public class Processo : Entity<Guid>
    {
        public string Area { get; set; }
        public string Assunto { get; set; }
        public string Classe { get; set; }
        public string NomeDoProcurador { get; set; }
        public string NumeroJudicial { get; set; }
        public string NumeroNoSaj { get; set; }
        public Parte ParteAtiva { get; set; }
        public Parte PartePassiva { get; set; }
        public bool SuspeitaDeLitispendencia { get; set; }
        protected override void SetId(Guid id) => Id = id;
    }
}