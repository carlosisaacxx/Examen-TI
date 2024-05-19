using AutoMapper;
using ExamenTI.Business.DTOs;
using ExamenTI.DataAccess.Entities;

namespace ExamenTI.Infrastructure.Configurations
{
    public class Mapping : Profile
    {
        public Mapping() {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Client, CreateClientDto>().ReverseMap();

            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<Store, CreateStoreDto>().ReverseMap();

            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Article, CreateArticleDto>().ReverseMap();
            
            CreateMap<User, UsersDto>().ReverseMap();
            CreateMap<User, CreateUsersDto>().ReverseMap();
        }
    }
}
