using RentACar.Application.ViewModels;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces
{
    public interface ICarPricingRepository :  IRepository<CarPricing>
    {
        List<CarPricing> GetCarPricingWithCars();
        List<CarPricing> GetCarPricingWith5Cars();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();



    }
}
