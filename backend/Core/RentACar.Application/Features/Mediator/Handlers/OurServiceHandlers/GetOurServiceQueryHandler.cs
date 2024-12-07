using MediatR;
using RentACar.Application.Features.Mediator.Queries.OurServiceQueries;
using RentACar.Application.Features.Mediator.Results.OurServiceResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Mediator.Handlers.OurOurServiceHandlers
{
    public class GetOurServiceQueryHandler : IRequestHandler<GetOurServiceQuery, List<GetOurServiceQueryResult>>
    {
        private readonly IRepository<OurService> _repository;
        public GetOurServiceQueryHandler(IRepository<OurService> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOurServiceQueryResult>> Handle(GetOurServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOurServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                Title = x.Title,
                Id = x.Id
            }).ToList();
        }
    }
}
