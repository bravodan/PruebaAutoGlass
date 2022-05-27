using FluentValidation;
using Models.DTO;

namespace API.Validators
{
    public class ProductItemCreateValidator : AbstractValidator<ProductItemCreateView>
    {
        public ProductItemCreateValidator()
        {
            RuleFor(pi => pi.Description).NotNull().WithMessage("Por favor, ingrese la descripción").NotEmpty().WithMessage("Por favor, ingrese la descripción");
            RuleFor(pi => pi.ManufacturingDate).LessThan(pi => pi.ValidityDate).WithMessage("La fecha de manufactura debe ser menor a la de vencimiento");
            RuleFor(pi => pi.CurrentSupplierId).NotNull().WithMessage("Debe especificar el proveedor").NotEmpty().WithMessage("Debe especificar el proveedor");
        }
    }
}
