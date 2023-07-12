using Application.Interfaces.Repositories;
using Domain.Models;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class ModelRepositoryAsync : GenericRepositoryAsync<Model>, IModelRepositoryAsync
    {
        public ModelRepositoryAsync(CarsContext dbContext) : base(dbContext)
        {
        }
    }
}
