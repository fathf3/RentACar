using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{

    public class CarRepository : ICarRepository
    {
        private readonly RentACarContext _context;
        public CarRepository(RentACarContext context) 
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
    }
}
