using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly RentACarContext _context;
        public StatisticsRepository(RentACarContext context)
        {
            _context = context;
        }
      

        public string GetBrandNameByMaxCar()
        {
            //en fazla araçlı marka
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = _context.Cars.GroupBy(x => x.Id).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.Id == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

 
        public decimal GetAvgRentPriceForDaily()
        {
            //günlük ortalama araç kiralama fiyatı
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.Id).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.Id).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.Id).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //günlük fiyatı en yüksek araç 
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.Id).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.Id == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            //Select * From CarPricings where Amount=(Select Min(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.Id).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.Id == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Miles <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            //otomatik vitesli araba sayısı
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
