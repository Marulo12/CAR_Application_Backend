using Application.DTOs.Car;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models;
using MediatR;


namespace Application.Feactures.Cars.Commands.NewCar
{
    public class NewCar: IRequest<IResponse<CarDTO>>
    {
        public NewCarDTO NewCarDto { get; set; } = null!;
    }

    public class NewCarHandler : IRequestHandler<NewCar, IResponse<CarDTO>>
    {
        private readonly ICarRepositoryAsync carRepositoryAsync;
        private readonly IMapper mapper;

        public NewCarHandler(ICarRepositoryAsync carRepositoryAsync, IMapper mapper)
        {
            this.carRepositoryAsync = carRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<IResponse<CarDTO>> Handle(NewCar request, CancellationToken cancellationToken)
        {
            try
            {
              var car = await carRepositoryAsync.AddAsync(mapper.Map<Car>(request.NewCarDto));
              return new Response<CarDTO>("Automovil creado con exito", entity: mapper.Map<CarDTO>(car));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
                     
        }
    }
}
