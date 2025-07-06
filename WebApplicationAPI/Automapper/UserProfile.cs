using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterRequest , IdentityUser>().ReverseMap();
            CreateMap<UserResponse, IdentityUser>().ReverseMap();
            CreateMap<UserLoginRequest, IdentityUser>().ReverseMap();


        }
    }
}
