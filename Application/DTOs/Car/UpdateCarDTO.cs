
namespace Application.DTOs.Car
{
    public class UpdateCarDTO
    {
        public long Id { get; set; }
        public double? Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public int Mileage { get; set; }
        public string VIN { get; set; } = null!;
        public long IdModel { get; set; } 
        public long IdBrand { get; set; } 
    }
}
