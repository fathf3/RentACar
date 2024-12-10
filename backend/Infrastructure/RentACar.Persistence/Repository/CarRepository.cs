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

    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(RentACarContext context) : base(context)
        {
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values =  _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }
        public List<Car> GetLast5CarsWithBrands()
        { 
                return _context.Cars.Include(x => x.Brand).Take(5).OrderByDescending(x => x.Id).ToList(); 
        }
    }
}
