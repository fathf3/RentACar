namespace RentACar.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeaklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        

    }
}
