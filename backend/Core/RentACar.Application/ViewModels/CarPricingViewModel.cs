using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.ViewModels
{
    public class CarPricingViewModel
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeaklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        

    }
}
