namespace Domain.Models
{
    public class Car
    {
        public long Id { get; set; }
        public double? Price { get; set; }
        public int Year { get; set; }
        public string Color { get; set; } = null!;
        public int Mileage { get; set; }
        public string VIN { get; set; } = null!;
        public long  IdModel { get; set; }
        public long IdBrand { get; set; }

        public virtual Model ModelNavigation { get; set; } = null!;
        public virtual Brand BrandNavigation { get; set; } = null!;
    }
}
