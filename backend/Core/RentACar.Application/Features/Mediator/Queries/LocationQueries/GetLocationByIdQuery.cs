using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public int id { get; set; }

        public GetLocationByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
