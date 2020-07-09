using AutoMapper;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards.Atos;

namespace Dotnet5.Elasticsearch.Client.Services.Profiles.Atos
{
    public class AtoProfile : Profile
    {
        public AtoProfile()
        {
            CreateMap<AtoModel, Ato>().ReverseMap();
        }
    }
}