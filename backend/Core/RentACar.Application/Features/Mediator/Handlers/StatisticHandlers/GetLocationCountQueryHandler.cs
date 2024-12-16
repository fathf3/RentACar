using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticQueries;
using RentACar.Application.Features.Mediator.Results.StatisticResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetLocationCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = value
            };
        }
    }
}
