using Application.DTOs.Car;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.Feactures.Cars.Queries.GetCarById
{
    public class GetCarById : IRequest<CarDTO>
    {
        public long IdCar { get; set; }
    }

    internal class GetCarByIdHandler : IRequestHandler<GetCarById, CarDTO>
    {
        private readonly ICarRepositoryAsync carRepositoryAsync;
        private readonly IMapper mapper;

        public GetCarByIdHandler(ICarRepositoryAsync carRepositoryAsync, IMapper mapper)
        {
            this.carRepositoryAsync = carRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<CarDTO> Handle(GetCarById request, CancellationToken cancellationToken)
        {
            var car = await carRepositoryAsync.GetByIdAsync(request.IdCar,
                 new List<Expression<Func<Car, object>>>()
                     {
                         s =>  s.BrandNavigation,
                         s =>  s.ModelNavigation
                     }
                );
            var carDTO = mapper.Map<CarDTO>(car);
            return carDTO;
        }
    }
}
