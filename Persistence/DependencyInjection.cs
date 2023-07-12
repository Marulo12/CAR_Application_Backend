using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarsContext>(
            dbContextOptions => dbContextOptions
            .UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 32)))
              .EnableSensitiveDataLogging()
              .EnableDetailedErrors());

           services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
           services.AddTransient<IBrandRepositoryAsync, BrandRepositoryAsync>();
           services.AddTransient<IModelRepositoryAsync, ModelRepositoryAsync>();
            services.AddTransient<ICarRepositoryAsync, CarRepositoryAsync>();
        }
    }
}
