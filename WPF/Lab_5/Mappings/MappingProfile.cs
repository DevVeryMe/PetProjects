using AutoMapper;
using Lab_5.Models;
using Lab_5.ViewModels;

namespace Lab_5.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NinjaModel, NinjaViewModel>().ReverseMap();

            CreateMap<DataModel, DataViewModel>().ReverseMap();
        }
    }
}