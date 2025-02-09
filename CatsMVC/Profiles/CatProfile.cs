using AutoMapper;
using CatsMVC.Data.Entities;
using CatsMVC.DTOs;

namespace CatsMVC.Profiles
{
    public class CatProfile : Profile
    {
        public CatProfile()
        {
            CreateMap<Cat, CatDTO>()
                .ReverseMap();
        }
    }
}
