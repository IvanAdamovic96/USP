using FluentValidation;
using USP.Application.Common.Validators;

namespace USP.Application.Users.Commands;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(x => x.User).NotNull();
        RuleFor(x => x.User).SetValidator(new EditUserDtoValidator());

    }
}