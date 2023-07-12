namespace Application.DTOs.Car
{
    public class CarDTO
    {
        public long Id { get; set; }
        public double? Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public int Mileage { get; set; }
        public string VIN { get; set; } = null!;
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
