
namespace Domain.Models
{
    public class Brand
    {
     
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Model> Models { get; set; } = new HashSet<Model>();
        public virtual ICollection<Car>  Cars { get; set; } = new HashSet<Car>();
    }
}
