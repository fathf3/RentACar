﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReviewQueries;
using RentACar.Application.Features.Mediator.Results.ReviewResults;
using RentACar.Application.Interfaces;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;
        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                CarID = x.CarID,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaytingValue = x.RaytingValue,
                ReviewDate = x.ReviewDate,
                ReviewID = x.Id
            }).ToList();
        }
    }
}
