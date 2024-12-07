using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.OurServiceCommands
{
    public class CreateOurServiceCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
    public class RemoveOurServiceCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveOurServiceCommand(int id)
        {
            Id = id;
        }
    }
    public class UpdateOurServiceCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
