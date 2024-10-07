using FluentValidation;

namespace USP.Application.Product.Commands;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product.Name).MinimumLength(3);
        RuleFor(x => x.Product.Name).MaximumLength(15);
        RuleFor(x => x.Product.Description).MinimumLength(15);
        RuleFor(x => x.Product.Description).MaximumLength(150);
        RuleFor(x => x.Product.Price).GreaterThan(10m);
        RuleFor(x => x.Product.Price).LessThanOrEqualTo(50000m);
    }
}