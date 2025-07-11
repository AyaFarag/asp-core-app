using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApplicationAPI.DTO;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterRequest , UserModel>().ReverseMap();
            CreateMap<UserResponse, UserModel>().ReverseMap();
            CreateMap<UserLoginRequest, UserModel>().ReverseMap();


        }
    }
}
