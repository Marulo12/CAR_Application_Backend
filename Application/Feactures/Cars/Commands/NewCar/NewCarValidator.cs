using FluentValidation;

namespace Application.Feactures.Cars.Commands.NewCar
{
    public class NewCarValidator: AbstractValidator<NewCar>
    {
        public NewCarValidator() {            
            RuleFor(s => s.NewCarDto.IdModel).NotEmpty().NotNull().WithMessage("El id del modelo es requerido");
            RuleFor(s => s.NewCarDto.IdBrand).NotEmpty().NotNull().WithMessage("El id del marca es requerido");
            RuleFor(s => s.NewCarDto.Year).NotEmpty().NotNull().WithMessage("El año es requerido");
            RuleFor(s => s.NewCarDto.Color).NotEmpty().NotNull().WithMessage("El color es requerido");
            RuleFor(s => s.NewCarDto.VIN).NotEmpty().NotNull().WithMessage("El VIN es requerido");
            RuleFor(s => s.NewCarDto.Mileage).NotNull().WithMessage("El Kilometraje es requerido");
        }
    }
}
