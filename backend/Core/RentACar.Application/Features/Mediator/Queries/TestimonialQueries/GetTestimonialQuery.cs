using MediatR;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;

namespace RentACar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
