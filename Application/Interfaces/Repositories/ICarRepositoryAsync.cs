using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface ICarRepositoryAsync: IGenericRepositoryAsync<Car>
    {
        Task<IReadOnlyList<Car>> GetCarsAsync();
    }
}
