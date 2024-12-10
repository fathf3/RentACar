using RentACar.Dto.BrandDtos;

namespace RentACar.Dto.CarDtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public int Miles { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public IList<ResultBrandDto> Brands { get; set; }
    }
}
