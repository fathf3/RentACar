using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{
    public class CarPricingRepository : Repository<CarPricing>, ICarPricingRepository
    {
        public CarPricingRepository(RentACarContext context) : base(context)
        {
           
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToList();
            return values;
        }
		public List<CarPricing> GetCarPricingWith5Cars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).Take(5).ToList();
			return values;
		}
        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            var query = from car in _context.Cars
                        join carPricing in _context.CarPricings on car.Id equals carPricing.CarId
                        join pricing in _context.Pricings on carPricing.PricingId equals pricing.Id
                        join brand in _context.Brands on car.BrandId equals brand.Id
                        group new { car, carPricing, pricing } by new {car.Image, car.Model, brand.Name } into g
                        select new CarPricingViewModel
                        {
                            ImageUrl = g.Key.Image,
                            Model = g.Key.Model,
                            BrandName = g.Key.Name,
                            DailyPrice = g.Where(x => x.pricing.Name == "Günlük").Sum(x => x.carPricing.Amount),
                            WeaklyPrice = g.Where(x => x.pricing.Name == "Haftalık").Sum(x => x.carPricing.Amount),
                            MonthlyPrice = g.Where(x => x.pricing.Name == "Aylık").Sum(x => x.carPricing.Amount)
                        }; 

            // Sonuçları bir listeye aktar
            var result = query.ToList();
            return result;
        }
       
	}
}
