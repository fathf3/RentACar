using MediatR;
using RentACar.Application.Features.Mediator.Results.OurServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.OurServiceQueries
{
    public class GetOurServiceByIdQuery : IRequest<GetOurServiceByIdQueryResult>
    {
        public int Id { get; set; }

        public GetOurServiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
