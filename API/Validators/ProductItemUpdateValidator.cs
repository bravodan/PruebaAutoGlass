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
            RuleFor(pi => pi.CurrentSupplierId).NotNull().WithMessage("Por favor, ingrese el id del proveedor")
                .NotEmpty().When(x => !Equals(x.ObjNewSupplier, null))
                .WithMessage("Por favor, ingrese el id del proveedor");
            RuleFor(pi => pi.ObjNewSupplier).NotNull()
                .WithMessage("Por favor, ingrese la información del proveedor")
                .NotEmpty().When(x => !Equals(x.CurrentSupplierId, null)).WithMessage("Por favor, ingrese la información del proveedor");
            RuleFor(pi => pi.ManufacturingDate).LessThan(pi => pi.ValidityDate).WithMessage("La fecha de manufactura debe ser menor a la de vencimiento");
        }
    }
}
