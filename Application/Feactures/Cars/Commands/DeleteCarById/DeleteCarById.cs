using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using MediatR;


namespace Application.Feactures.Cars.Commands.DeleteCarById
{
    public class DeleteCarById : IRequest<IResponse<string>>
    {
        public long IdCar { get; set; }
    }

    internal class DeleteCarByIdHandler : IRequestHandler<DeleteCarById, IResponse<string>>
    {
        private readonly ICarRepositoryAsync carRepositoryAsync;

        public DeleteCarByIdHandler(ICarRepositoryAsync carRepositoryAsync)
        {
            this.carRepositoryAsync = carRepositoryAsync;
        }

        public async Task<IResponse<string>> Handle(DeleteCarById request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await carRepositoryAsync.GetByIdAsync(request.IdCar);

                if (car == null)
                {
                    return new Response<string>("No existe el automovil con ese id", false);
                }

                await carRepositoryAsync.DeleteAsync(car!);
                return new Response<string>("Automovil eliminado con exito", true);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}
