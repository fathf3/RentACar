﻿using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        List<Car> GetCarsListWithBrand();
        List<Car> GetLast5CarsWithBrands();
    }
}
