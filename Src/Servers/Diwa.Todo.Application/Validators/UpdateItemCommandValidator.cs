using Diwa.Todo.Application.Commands;
using FluentValidation;

namespace Diwa.Todo.Application.Validators;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull();

        RuleFor(x => x.Text)
            .NotNull()
            .NotEmpty()
            .WithMessage("The item text can't be null or empty.");

        RuleFor(x => x.IsDone)
            .NotNull();
    }
}