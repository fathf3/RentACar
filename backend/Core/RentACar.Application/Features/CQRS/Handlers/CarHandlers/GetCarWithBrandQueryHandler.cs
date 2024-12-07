using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values =  _repository.GetCarsListWithBrand();
            
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Id = x.Id,
                Image = x.Image,
                Luggage = x.Luggage,
                Miles = x.Miles,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}

