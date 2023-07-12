
namespace Domain.Models
{
    public class Brand
    {
        Brand()
        {
           Models = new HashSet<Model>();
           Cars = new HashSet<Car>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Car>  Cars { get; set; }
    }
}
