using MediatR;
using RentACar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentACar.Application.Features.Mediator.Results.TestimonialResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        public GetPricingByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Comment = values.Comment,
                Title = values.Title,
                ImageUrl = values.ImageUrl
            };
        }
    }
}
