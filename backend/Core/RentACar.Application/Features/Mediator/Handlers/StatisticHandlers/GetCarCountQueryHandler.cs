using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticQueries;
using RentACar.Application.Features.Mediator.Results.StatisticResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        //private readonly ICarRepository _repository;

        //public GetCarCountQueryHandler(ICarRepository repository)
        //{
        //    _repository = repository;
        //}
        private readonly IStatisticsRepository _repository;

        public GetCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCount();
            return new GetCarCountQueryResult
            {
                CarCount = value,
            };
        }
    }
}
