using MediatR;
using RentACar.Application.Features.Mediator.Results.PricingResults;

namespace RentACar.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {

    }
}
