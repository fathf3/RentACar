using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;
using RentACar.Application.Features.Mediator.Results.CarFeatureResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeaturesByCarID(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available = x.Available,
                CarFeatureID = x.Id,
                FeatureID = x.FeatureId,
                FeatureName = x.Feature.Name
            }).ToList();
        }
    }
}
