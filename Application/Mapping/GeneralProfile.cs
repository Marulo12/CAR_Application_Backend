using Application.DTOs.Brand;
using Application.DTOs.Car;
using Application.DTOs.Model;
using AutoMapper;
using Domain.Models;

namespace Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
           CreateMap<Brand, BrandDTO>().ReverseMap();
           CreateMap<Model, ModelDTO>().ReverseMap();
           CreateMap<Car, CarDTO>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.BrandNavigation.Name.ToUpper()))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.ModelNavigation.Name.ToUpper()))
                .ReverseMap();
        }
    }
}
