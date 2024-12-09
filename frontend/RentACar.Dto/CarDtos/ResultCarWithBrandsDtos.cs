namespace RentACar.Dto.CarDtos
{
    public class ResultCarWithBrandsDtos
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public int Miles { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
