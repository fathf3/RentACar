using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{
    public class RentACarRepository : Repository<RentCar>, IRentACarRepository
    {
        public RentACarRepository(RentACarContext context) : base(context)
        {
        }

        public async Task<List<RentCar>> GetByFilterAsync(Expression<Func<RentCar, bool>> filter)
        {
            var values = await _context.RentCars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}
