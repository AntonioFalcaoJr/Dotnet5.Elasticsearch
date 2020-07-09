using AutoMapper;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Processos;

namespace Dotnet5.Elasticsearch.Client.Services.Profiles.Processos
{
    public class ProcessoProfile : Profile
    {
        public ProcessoProfile()
        {
            CreateMap<ProcessoModel, Processo>().ReverseMap();
            CreateMap<ParteModel, Parte>().ReverseMap();
        }
    }
}