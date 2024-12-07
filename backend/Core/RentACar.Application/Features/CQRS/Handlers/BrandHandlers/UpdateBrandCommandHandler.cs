﻿using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}