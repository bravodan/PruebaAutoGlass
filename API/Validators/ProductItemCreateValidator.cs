using FluentValidation;
using Models.DTO;

namespace API.Validators
{
    public class ProductItemCreateValidator : AbstractValidator<ProductItemCreateView>
    {
        public ProductItemCreateValidator()
        {
            RuleFor(pi => pi.Description).NotNull().WithMessage("Por favor, ingrese una descripción").NotEmpty().WithMessage("Por favor, ingrese una descripción");
            RuleFor(pi => pi.ManufacturingDate).LessThan(pi => pi.ValidityDate).WithMessage("La fecha de manufactura debe ser menor a la de vencimiento");
            RuleFor(pi => pi.SupplierId).NotNull().WithMessage("Debe especificar el proveedor").NotEmpty().WithMessage("Debe especificar el proveedor");
        }
    }
}
