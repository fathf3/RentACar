﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommand
    {
        
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public string Miles { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}