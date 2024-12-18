﻿using MediatR;

namespace RentACar.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public int id { get; set; }

        public RemoveFooterAddressCommand(int id)
        {
            this.id = id;
        }
    }
}
