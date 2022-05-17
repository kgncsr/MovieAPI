using AutoMapper;
using MovieAPI.Entities;
using MovieAPI.ServiceTier.Dtos;
using MovieAPI.ServiceTier.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAPI.ModelTier;
using MovieAPI.ServiceTier.Dtos.Actor;
using MovieAPI.ServiceTier.Dtos.User;

namespace MovieAPI.ServiceTier.AutoMapper.Profiles
{

    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>().ReverseMap();
            CreateMap<MovieManagerDto, Movie>().ReverseMap();
            CreateMap<SaveManagerDto, Manager>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
            CreateMap<UpdateActor, Actor>().ReverseMap();
            CreateMap<SaveActor, Actor>().ReverseMap();
            CreateMap<UpdateActor,Actor>().ReverseMap();
            CreateMap<ActorDto,Actor>().ReverseMap();
            CreateMap<Movie,MovieCreateDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();

        }
   
    }
}
