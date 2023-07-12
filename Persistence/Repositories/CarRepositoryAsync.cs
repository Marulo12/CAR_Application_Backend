using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class CarRepositoryAsync : GenericRepositoryAsync<Car>, ICarRepositoryAsync
    {
        private readonly CarsContext dbContext;
        public CarRepositoryAsync(CarsContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        
         public async Task<IReadOnlyList<Car>> GetCarsAsync()
        {
            var cars = await dbContext.Cars.Include(s => s.BrandNavigation).Include(s => s.ModelNavigation)
                      .OrderBy(s => s.BrandNavigation.Name).ThenBy(s => s.ModelNavigation.Name).ToListAsync();
            return cars;
        }
    }
}
