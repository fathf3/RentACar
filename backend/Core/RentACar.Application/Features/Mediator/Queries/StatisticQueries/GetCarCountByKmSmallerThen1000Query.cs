using MediatR;
using RentACar.Application.Features.Mediator.Results.StatisticResults;

namespace RentACar.Application.Features.Mediator.Queries.StatisticQueries
{
    public class GetCarCountByKmSmallerThen1000Query : IRequest<GetCarCountByKmSmallerThen1000QueryResult>
    {
    }
}
