using AutoMapper;
using Dotnet5.Elasticsearch.Domain.Entities.Cards;
using Dotnet5.Elasticsearch.Domain.Models.Cards;

namespace Dotnet5.Elasticsearch.Client.Services.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardModel, Card>().ReverseMap();
        }
    }
}