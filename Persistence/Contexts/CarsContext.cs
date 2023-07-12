using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Contexts
{
    public class CarsContext : DbContext
    {
      public CarsContext() { 
        }
        public CarsContext(DbContextOptions<CarsContext> options)
           : base(options)
        {
        }
      
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Brand>(entity => {
                entity.ToTable("Brands");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();                                
            });


            modelBuilder.Entity<Car>(entity => {
                entity.ToTable("Cars");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price).HasColumnName("Price");
                entity.Property(e => e.VIN).HasColumnName("VIN").IsRequired();
                entity.Property(e => e.Color).HasColumnName("Color").IsRequired();
                entity.Property(e => e.Year).HasColumnName("Year").IsRequired();
                entity.Property(e => e.Mileage).HasColumnName("Mileage").IsRequired();
                entity.Property(e => e.IdBrand).HasColumnName("IdBrand").IsRequired();
                entity.Property(e => e.IdModel).HasColumnName("IdModel").IsRequired();


                entity.HasOne(e => e.BrandNavigation)
               .WithMany(e => e.Cars)
               .HasForeignKey(e => e.IdBrand)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Cars_Brands");

                entity.HasOne(e => e.ModelNavigation)
               .WithMany(e => e.Cars)
               .HasForeignKey(e => e.IdModel)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Cars_Models");
            });


            modelBuilder.Entity<Model>(entity => {
                entity.ToTable("Models");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                entity.Property(e => e.IdBrand).HasColumnName("IdBrand").IsRequired();                
                entity.HasOne(e => e.BrandNavigation)
               .WithMany(e => e.Models)
               .HasForeignKey(e => e.IdBrand)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Models_Brands");
            });
        }

    }
}
