using Application.DTOs.Car;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Feactures.Cars.Queries.GetCars
{
    public class GetCars: IRequest<IReadOnlyList<CarDTO>>
    {
    }

    public class GetCarsHandler : IRequestHandler<GetCars, IReadOnlyList<CarDTO>>
    {
        private readonly ICarRepositoryAsync carRepositoryAsync;
        private readonly IMapper mapper;

        public GetCarsHandler(ICarRepositoryAsync carRepositoryAsync, IMapper mapper)
        {
            this.carRepositoryAsync = carRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<CarDTO>> Handle(GetCars request, CancellationToken cancellationToken)
        {
            var cars = await carRepositoryAsync.GetCarsAsync();
            var carsDTO = mapper.Map<IReadOnlyList<CarDTO>>(cars);

            return carsDTO;
        }
    }
}
