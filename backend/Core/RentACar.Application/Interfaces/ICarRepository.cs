﻿using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrand(); 
    }
}