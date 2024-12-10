using AutoMapper;
using RentACar.Dto.CarDtos;

namespace RentACar.WebUI.AutoMapper
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<ResultCar, CreateCarDto>().ReverseMap();
            CreateMap<ResultCar, UpdateCarDto>().ReverseMap();
        }
    }
}
