using RentACar.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {

            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                
                BrandId = values.BrandId,
                BigImageUrl = values.BigImageUrl,
                Fuel = values.Fuel,
                Id = values.Id,
                Image = values.Image,
                Luggage = values.Luggage,
                Miles = values.Miles,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission
            };
        }
    }
}
