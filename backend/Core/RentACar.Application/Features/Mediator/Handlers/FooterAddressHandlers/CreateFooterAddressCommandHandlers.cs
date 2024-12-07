using MediatR;
using RentACar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandlers : IRequestHandler<CreateFooterAddressCommand>
    {

        private readonly IRepository<FooterAddress> _Repository;

        public CreateFooterAddressCommandHandlers(IRepository<FooterAddress> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _Repository.CreateAsync(new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                PhoneNumber = request.Phone
            });
        }
    }
}
