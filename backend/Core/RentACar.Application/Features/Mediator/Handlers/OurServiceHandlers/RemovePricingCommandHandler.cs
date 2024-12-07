using MediatR;
using RentACar.Application.Features.Mediator.Commands.OurServiceCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.OurOurServiceHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemoveOurServiceCommand>
    {
        private readonly IRepository<OurService> _repository;

        public RemovePricingCommandHandler(IRepository<OurService> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOurServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
