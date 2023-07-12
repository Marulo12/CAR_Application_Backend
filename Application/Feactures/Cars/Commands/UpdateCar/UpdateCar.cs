using Application.DTOs.Car;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq.Expressions;

namespace Application.Feactures.Cars.Commands.UpdateCarById
{
    public class UpdateCar : IRequest<IResponse<CarDTO>>
    {
        public UpdateCarDTO UpdateCarDTO { get; set; } = null!;
    }

    public class UpdateCarByIdHandler : IRequestHandler<UpdateCar, IResponse<CarDTO>>
    {
        private readonly ICarRepositoryAsync carRepositoryAsync;
        private readonly IMapper mapper;

        public UpdateCarByIdHandler(ICarRepositoryAsync carRepositoryAsync, IMapper mapper)
        {
            this.carRepositoryAsync = carRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<IResponse<CarDTO>> Handle(UpdateCar request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await carRepositoryAsync.GetByIdAsync(request.UpdateCarDTO.Id, new List<Expression<Func<Car, object>>>()
                     {
                         s =>  s.BrandNavigation,
                         s =>  s.ModelNavigation
                     });

                if (car == null)
                {
                    return new Response<CarDTO>("No existe un automovil con ese id", false);
                }

                car.Year = request.UpdateCarDTO.Year;
                car.IdBrand = request.UpdateCarDTO.IdBrand;
                car.Price = request.UpdateCarDTO.Price;
                car.Color = request.UpdateCarDTO.Color;
                car.IdModel = request.UpdateCarDTO.IdModel;
                car.VIN = request.UpdateCarDTO.VIN;
                car.Mileage = request.UpdateCarDTO.Mileage;

                await carRepositoryAsync.UpdateAsync(car);

                return new Response<CarDTO>("Automovil modificado con exito", true, entity: mapper.Map<CarDTO>(car));
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}
