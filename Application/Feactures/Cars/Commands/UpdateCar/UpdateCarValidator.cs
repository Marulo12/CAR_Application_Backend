using FluentValidation;

namespace Application.Feactures.Cars.Commands.UpdateCarById
{
    public class UpdateCarValidator : AbstractValidator<UpdateCar>
    {
        public UpdateCarValidator()
        {
            RuleFor(s => s.updateCar.Id).NotEmpty().NotNull().WithMessage("El id del automovil es requerido");
            RuleFor(s => s.updateCar.IdModel).NotEmpty().NotNull().WithMessage("El id del modelo es requerido");
            RuleFor(s => s.updateCar.IdBrand).NotEmpty().NotNull().WithMessage("El id del marca es requerido");
            RuleFor(s => s.updateCar.Year).NotEmpty().NotNull().WithMessage("El año es requerido");
            RuleFor(s => s.updateCar.Color).NotEmpty().NotNull().WithMessage("El color es requerido");
            RuleFor(s => s.updateCar.VIN).NotEmpty().NotNull().WithMessage("El VIN es requerido");
            RuleFor(s => s.updateCar.Mileage).NotEmpty().NotNull().WithMessage("El Kilometraje es requerido");
        }
    }
}
