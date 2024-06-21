using Diwa.Todo.Application.Commands;
using FluentValidation;

namespace Diwa.Todo.Application.Validators;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .WithMessage("The item text can't be null or empty.");
    }
}