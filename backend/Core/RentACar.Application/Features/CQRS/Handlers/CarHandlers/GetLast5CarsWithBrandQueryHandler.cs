using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BrandId = x.BrandId,
                BigImageUrl = x.BigImageUrl,
                Id = x.Id,
                Image = x.Image,
                Fuel = x.Fuel,
                Miles = x.Miles,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
