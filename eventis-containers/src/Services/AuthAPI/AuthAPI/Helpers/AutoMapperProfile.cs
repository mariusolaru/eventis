using AuthAPI.DTOs;
using AuthAPI.Entities;
using AutoMapper;

namespace AuthAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
