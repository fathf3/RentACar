using MediatR;
using RentACar.Application.Features.Mediator.Queries.OurServiceQueries;
using RentACar.Application.Features.Mediator.Results.OurServiceResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.OurOurServiceHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetOurServiceByIdQuery, GetOurServiceByIdQueryResult>
    {
        private readonly IRepository<OurService> _repository;
        public GetPricingByIdQueryHandler(IRepository<OurService> repository)
        {
            _repository = repository;
        }

        public async Task<GetOurServiceByIdQueryResult> Handle(GetOurServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOurServiceByIdQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                Title = values.Title,
                IconUrl = values.IconUrl
            };
        }
    }
}
