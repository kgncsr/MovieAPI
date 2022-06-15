using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.User;

namespace MovieAPI.ServiceTier.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserAddTestDto, UserDto>().ReverseMap();
            CreateMap<UserAddTestDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
