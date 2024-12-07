using MediatR;
using RentACar.Application.Features.Mediator.Commands.OurServiceCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.OurOurServiceHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreateOurServiceCommand>
    {
        private readonly IRepository<OurService> _repository;
        public CreatePricingCommandHandler(IRepository<OurService> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOurServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new OurService
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title
            });
        }
    }
}
