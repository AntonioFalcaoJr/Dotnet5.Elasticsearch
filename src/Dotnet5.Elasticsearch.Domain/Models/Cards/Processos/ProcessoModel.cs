namespace Dotnet5.Elasticsearch.Domain.Models.Cards.Processos
{
    public class ProcessoModel
    {
        public string Area { get; set; }
        public string Assunto { get; set; }
        public string Classe { get; set; }
        public bool Litispendencia { get; set; }
        public string NomeDoProcurador { get; set; }
        public string NumeroJudicial { get; set; }
        public string NumeroNoSaj { get; set; }
        public ParteModel ParteAtiva { get; set; }
        public ParteModel PartePassiva { get; set; }
    }
}