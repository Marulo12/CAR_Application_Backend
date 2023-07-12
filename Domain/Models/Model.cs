namespace Domain.Models
{
    public class Model
    {       
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long IdBrand { get; set; }

        public virtual Brand BrandNavigation { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
