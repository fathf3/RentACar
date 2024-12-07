using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
    {
    }
}
