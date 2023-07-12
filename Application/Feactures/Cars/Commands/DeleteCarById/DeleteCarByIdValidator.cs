using FluentValidation;


namespace Application.Feactures.Cars.Commands.DeleteCarById
{
    internal class DeleteCarByIdValidator: AbstractValidator<DeleteCarById>
    {
        public DeleteCarByIdValidator() {
            RuleFor(s => s.IdCar)
                  .NotEmpty().WithMessage("El id del automovil es requerido")
                  .NotNull().WithMessage("El id del automovil es requerido");
        }
    }
}
