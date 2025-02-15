using AutoMapper;
using CatsMVC.Data.Entities;
using CatsMVC.DTOs;

namespace CatsMVC.Profiles
{
    public class VetProfile : Profile
    {
        public VetProfile()
        {
            CreateMap<Vet, VetDTO>()
                .ReverseMap();
        }
    }
}
