﻿using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Title = command.Title;
            values.Description = command.Description;
            values.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
