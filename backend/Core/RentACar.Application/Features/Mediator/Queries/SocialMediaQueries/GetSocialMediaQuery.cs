using MediatR;
using RentACar.Application.Features.Mediator.Results.SocialMediaResults;

namespace RentACar.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
