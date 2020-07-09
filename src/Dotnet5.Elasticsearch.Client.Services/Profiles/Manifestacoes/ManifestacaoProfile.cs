using AutoMapper;
using Dotnet5.Elasticsearch.Domain.Entities;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Manifestacoes;
using Dotnet5.Elasticsearch.Domain.Entities.Cards.Processos;
using Dotnet5.Elasticsearch.Domain.Models;
using Dotnet5.Elasticsearch.Domain.Models.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Manifestacoes;

namespace Dotnet5.Elasticsearch.Client.Services.Profiles.Manifestacoes
{
    public class ManifestacaoProfile : Profile
    {
        public ManifestacaoProfile()
        {
            CreateMap<ManifestacaoModel, Manifestacao>().ReverseMap();
            CreateMap<ProcessoModel, Processo>().ReverseMap();
            CreateMap<AssessorModel, Assessor>().ReverseMap();
            CreateMap<PedidoModel, Pedido>().ReverseMap();
            CreateMap<RedistribuicaoModel, Redistribuicao>().ReverseMap();
            CreateMap<TransferenciaModel, Transferencia>().ReverseMap();
            CreateMap<DocumentoModel, Documento>().ReverseMap();
        }
    }
}