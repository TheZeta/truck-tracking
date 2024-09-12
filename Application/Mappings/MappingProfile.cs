using AutoMapper;
using BlazorWasmClient.Shared.DTOs;
using Core.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Truck, TruckDto>().ReverseMap();
        }
    }
}
