using AutoMapper;
using UsersServiceApi.Application.Dtos;
using UsersServiceApi.Domain.Models;

namespace UsersServiceApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //source -> target 
            CreateMap<User, UserDto>();
            CreateMap<UserRegisterDto, User>()
                .ForMember((x => x.HashedPassword), x => x.MapFrom(src => src.Password));
        }
    }
}
