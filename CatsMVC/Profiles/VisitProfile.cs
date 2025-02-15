using AutoMapper;
using CatsMVC.DTOs;
using CatsMVC.Data.Entities;

namespace CatsMVC.Profiles
{
    public class VisitProfile : Profile
    {
        public VisitProfile()
        {
            CreateMap<CatVisitDTO, Visit>()
                .ReverseMap();
        }
    }
}
