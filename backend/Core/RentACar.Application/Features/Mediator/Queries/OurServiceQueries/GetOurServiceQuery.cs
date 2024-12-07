using MediatR;
using RentACar.Application.Features.Mediator.Results.OurServiceResults;

namespace RentACar.Application.Features.Mediator.Queries.OurServiceQueries
{
    public class GetOurServiceQuery : IRequest<List<GetOurServiceQueryResult>>
    {
    }
}
