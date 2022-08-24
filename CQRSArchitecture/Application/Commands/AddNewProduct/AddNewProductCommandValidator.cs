using FluentValidation;

namespace Application.Commands.AddNewProduct
{
    public class AddNewProductCommandValidator : AbstractValidator<AddNewProductCommand>
    {
        public AddNewProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product Name must be specified")
                        .MaximumLength(100).WithMessage("Product Name exceeds the authorized size 100");
            RuleFor(p => p.Description).MaximumLength(400).WithMessage("Product Description exceeds the authorized size which is 400");
        }
    }
}
