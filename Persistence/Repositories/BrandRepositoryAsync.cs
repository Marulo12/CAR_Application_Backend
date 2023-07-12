using Application.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepositoryAsync : GenericRepositoryAsync<Brand>, IBrandRepositoryAsync
    {
        public BrandRepositoryAsync(CarsContext dbContext) : base(dbContext)
        {
        }
    }
}
