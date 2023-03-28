using AutoMapper;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;

namespace SyZero.Blog.Application.MapProfile
{
    public class AppMapProfile : Profile
    {
        public AppMapProfile()
        {
            //CreateMap<User, CreateUserDto>();
            CreateMap<Login2Dto, LoginDto>();

            
        }
    }
}