using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWith5CarQueryHandler : IRequestHandler<GetCarPricingWith5CarQuery, List<GetCarPricingWith5CarQueryResult>>
	{
		private readonly ICarPricingRepository _repository;
		public GetCarPricingWith5CarQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarPricingWith5CarQueryResult>> Handle(GetCarPricingWith5CarQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWith5Cars();
			return values.Select(x => new GetCarPricingWith5CarQueryResult
			{
				Amount = x.Amount,
				CarPricingId = x.PricingId,
				Brand = x.Car.Brand.Name,
				CoverImageUrl = x.Car.Image,
				Model = x.Car.Model,
				Id = x.Id
			}).ToList();
		}
	}

}
