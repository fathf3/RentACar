﻿using MediatR;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;

namespace RentACar.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>
    {
    }
}
