using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.BrandId = command.BrandId;
            values.BigImageUrl = command.BigImageUrl;
            values.Fuel = command.Fuel;
            values.Image = command.Image;
            values.Luggage = command.Luggage;
            values.Miles = command.Miles;
            values.Model = command.Model;
            values.Seat = command.Seat;
            values.Transmission = command.Transmission;
            await _repository.UpdateAsync(values);
        }
    }
}
