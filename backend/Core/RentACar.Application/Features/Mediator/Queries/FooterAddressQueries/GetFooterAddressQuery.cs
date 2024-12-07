using MediatR;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;

namespace RentACar.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
