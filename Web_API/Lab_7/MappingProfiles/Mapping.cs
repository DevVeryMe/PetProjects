using AutoMapper;
using Lab_7.Dtos;
using Lab_7.Entities;
using Lab_7.ViewModels;

namespace Lab_7.MappingProfiles
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<NinjaEntity, NinjaDto>().ReverseMap();
            CreateMap<NinjaEquipmentEntity, NinjaEquipmentDto>().ReverseMap();

            CreateMap<NinjaDto, NinjaViewModel>().ReverseMap();
            CreateMap<NinjaEquipmentDto, NinjaViewModel>().ReverseMap();

            CreateMap<NinjaDto, CreateNinjaViewModel>().ReverseMap();
            CreateMap<NinjaEquipmentDto, CreateNinjaEquipmentViewModel>().ReverseMap();
        }
    }
}
