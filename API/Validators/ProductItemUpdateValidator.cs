using FluentValidation;
using Models.DTO;

namespace API.Validators
{
    public class ProductItemUpdateValidator : AbstractValidator<ProductItemUpdateView>
    {
        public ProductItemUpdateValidator()
        {
            RuleFor(pi => pi.Id).NotNull().WithMessage("Por favor, ingrese el identificador").NotEmpty().WithMessage("Por favor, ingrese el identificador");
            RuleFor(pi => pi.Description).NotNull().WithMessage("Por favor, ingrese la descripción").NotEmpty().WithMessage("Por favor, ingrese la descripción");
            RuleFor(pi => pi.ManufacturingDate).LessThan(pi => pi.ValidityDate).When(pi => pi.ValidityDate != null).WithMessage("La fecha de manufactura debe ser menor a la de vencimiento");
            RuleFor(pi => pi.ValidityDate).GreaterThan(pi => pi.ManufacturingDate).When(pi => pi.ManufacturingDate != null).WithMessage("La fecha de manufactura debe ser menor a la de vencimiento");
        }
    }
}
