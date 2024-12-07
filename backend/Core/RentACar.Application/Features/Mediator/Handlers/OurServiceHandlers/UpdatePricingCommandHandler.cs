using MediatR;
using RentACar.Application.Features.Mediator.Commands.OurServiceCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.OurOurServiceHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdateOurServiceCommand>
    {
        private readonly IRepository<OurService> _repository;
        public UpdatePricingCommandHandler(IRepository<OurService> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOurServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Description = request.Description;
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
