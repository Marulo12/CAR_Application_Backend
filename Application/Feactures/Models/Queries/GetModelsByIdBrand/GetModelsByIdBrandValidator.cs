using FluentValidation;


namespace Application.Feactures.Models.Queries.GetModelsByIdBrand
{
    public class GetModelsByIdBrandValidator: AbstractValidator<GetModelsByIdBrand>
    {
        public GetModelsByIdBrandValidator() {
            RuleFor(s => s.IdBrand)
                .NotEmpty().WithMessage("El id de la marca es requerido")
                .NotNull().WithMessage("El id de la marca es requerido");
        }
    }
}
