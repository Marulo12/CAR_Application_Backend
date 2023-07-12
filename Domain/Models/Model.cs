namespace Domain.Models
{
    public class Model
    {
        Model()
        {
            Cars = new HashSet<Car>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long IdBrand { get; set; }

        public virtual Brand BrandNavigation { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; }
    }
}
