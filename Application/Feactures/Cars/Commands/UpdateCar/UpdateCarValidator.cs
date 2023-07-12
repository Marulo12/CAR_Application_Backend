using FluentValidation;

namespace Application.Feactures.Cars.Commands.UpdateCarById
{
    public class UpdateCarValidator : AbstractValidator<UpdateCar>
    {
        public UpdateCarValidator()
        {
            RuleFor(s => s.UpdateCarDTO.Id).NotEmpty().NotNull().WithMessage("El id del automovil es requerido");
            RuleFor(s => s.UpdateCarDTO.IdModel).NotEmpty().NotNull().WithMessage("El id del modelo es requerido");
            RuleFor(s => s.UpdateCarDTO.IdBrand).NotEmpty().NotNull().WithMessage("El id del marca es requerido");
            RuleFor(s => s.UpdateCarDTO.Year).NotEmpty().NotNull().WithMessage("El año es requerido");
            RuleFor(s => s.UpdateCarDTO.Color).NotEmpty().NotNull().WithMessage("El color es requerido");
            RuleFor(s => s.UpdateCarDTO.VIN).NotEmpty().NotNull().WithMessage("El VIN es requerido");
            RuleFor(s => s.UpdateCarDTO.Mileage).NotEmpty().NotNull().WithMessage("El Kilometraje es requerido");
        }
    }
}

