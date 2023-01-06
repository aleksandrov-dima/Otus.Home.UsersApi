using AutoMapper;
using Otus.Home.UsersApi.Core.Domain.Administration;

namespace Otus.Home.UsersApi.Host.Models
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<User, UserShortResponse>();
            CreateMap<User, UserResponse>();
        }
    }
}